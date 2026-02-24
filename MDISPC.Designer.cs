namespace SPC_KDL
{
    partial class MDISPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDISPC));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInspection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonRetake = new System.Windows.Forms.ToolStripSplitButton();
            this.currentCharacteristicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allCharacteristicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEvent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemovePartNo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCharts = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonKeyboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLogOut = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDayPartsScannedHdr = new System.Windows.Forms.Label();
            this.lblDayPartsScannedData = new System.Windows.Forms.Label();
            this.lblShiftHdr = new System.Windows.Forms.Label();
            this.lblShiftData = new System.Windows.Forms.Label();
            this.lblLastSyncDateHdr = new System.Windows.Forms.Label();
            this.lblLastSyncDateData = new System.Windows.Forms.Label();
            this.pnlStation = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblShiftsPartsScannedHdr = new System.Windows.Forms.Label();
            this.lblShiftsPartsScannedData = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlStation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonScan,
            this.toolStripButtonInspection,
            this.toolStripSplitButtonRetake,
            this.toolStripButtonModify,
            this.toolStripButtonEvent,
            this.toolStripButtonRemovePartNo,
            this.toolStripButtonCharts,
            this.toolStripButtonKeyboard,
            this.toolStripButtonLogOut});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(1504, 46);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripButtonScan
            // 
            this.toolStripButtonScan.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonScan.Image")));
            this.toolStripButtonScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScan.Name = "toolStripButtonScan";
            this.toolStripButtonScan.Size = new System.Drawing.Size(112, 43);
            this.toolStripButtonScan.Text = "ScanPartNo[F1]";
            this.toolStripButtonScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonScan.ToolTipText = "ScanPartNo[F1]";
            this.toolStripButtonScan.Click += new System.EventHandler(this.toolStripButtonScan_Click);
            // 
            // toolStripButtonInspection
            // 
            this.toolStripButtonInspection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInspection.Image")));
            this.toolStripButtonInspection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInspection.Name = "toolStripButtonInspection";
            this.toolStripButtonInspection.Size = new System.Drawing.Size(105, 43);
            this.toolStripButtonInspection.Text = "Inspection[F2]";
            this.toolStripButtonInspection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonInspection.Click += new System.EventHandler(this.toolStripButtonInspection_Click);
            // 
            // toolStripSplitButtonRetake
            // 
            this.toolStripSplitButtonRetake.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSplitButtonRetake.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentCharacteristicToolStripMenuItem,
            this.allCharacteristicsToolStripMenuItem});
            this.toolStripSplitButtonRetake.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonRetake.Image")));
            this.toolStripSplitButtonRetake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonRetake.Name = "toolStripSplitButtonRetake";
            this.toolStripSplitButtonRetake.Size = new System.Drawing.Size(69, 43);
            this.toolStripSplitButtonRetake.Text = "Retake";
            this.toolStripSplitButtonRetake.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripSplitButtonRetake.ButtonClick += new System.EventHandler(this.toolStripSplitButtonRetake_ButtonClick);
            // 
            // currentCharacteristicToolStripMenuItem
            // 
            this.currentCharacteristicToolStripMenuItem.CheckOnClick = true;
            this.currentCharacteristicToolStripMenuItem.Name = "currentCharacteristicToolStripMenuItem";
            this.currentCharacteristicToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.currentCharacteristicToolStripMenuItem.Text = "Previous Characteristic";
            this.currentCharacteristicToolStripMenuItem.Click += new System.EventHandler(this.currentCharacteristicToolStripMenuItem_Click);
            // 
            // allCharacteristicsToolStripMenuItem
            // 
            this.allCharacteristicsToolStripMenuItem.CheckOnClick = true;
            this.allCharacteristicsToolStripMenuItem.Name = "allCharacteristicsToolStripMenuItem";
            this.allCharacteristicsToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.allCharacteristicsToolStripMenuItem.Text = "All Characteristics";
            this.allCharacteristicsToolStripMenuItem.Click += new System.EventHandler(this.allCharacteristicsToolStripMenuItem_Click);
            // 
            // toolStripButtonModify
            // 
            this.toolStripButtonModify.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonModify.Image")));
            this.toolStripButtonModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModify.Name = "toolStripButtonModify";
            this.toolStripButtonModify.Size = new System.Drawing.Size(83, 43);
            this.toolStripButtonModify.Text = "Modify[F4]";
            this.toolStripButtonModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonModify.Click += new System.EventHandler(this.toolStripButtonModify_Click);
            // 
            // toolStripButtonEvent
            // 
            this.toolStripButtonEvent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEvent.Image")));
            this.toolStripButtonEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEvent.Name = "toolStripButtonEvent";
            this.toolStripButtonEvent.Size = new System.Drawing.Size(74, 43);
            this.toolStripButtonEvent.Text = "Event[F5]";
            this.toolStripButtonEvent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEvent.Click += new System.EventHandler(this.toolStripButtonEvent_Click);
            // 
            // toolStripButtonRemovePartNo
            // 
            this.toolStripButtonRemovePartNo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemovePartNo.Image")));
            this.toolStripButtonRemovePartNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemovePartNo.Name = "toolStripButtonRemovePartNo";
            this.toolStripButtonRemovePartNo.Size = new System.Drawing.Size(86, 43);
            this.toolStripButtonRemovePartNo.Text = "Part No[F6]";
            this.toolStripButtonRemovePartNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRemovePartNo.Click += new System.EventHandler(this.toolStripButtonRemovePartNo_Click);
            // 
            // toolStripButtonCharts
            // 
            this.toolStripButtonCharts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCharts.Image")));
            this.toolStripButtonCharts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCharts.Name = "toolStripButtonCharts";
            this.toolStripButtonCharts.Size = new System.Drawing.Size(80, 43);
            this.toolStripButtonCharts.Text = "Charts[F9]";
            this.toolStripButtonCharts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCharts.ToolTipText = "Charts[F9]";
            this.toolStripButtonCharts.Click += new System.EventHandler(this.toolStripButtonCharts_Click);
            // 
            // toolStripButtonKeyboard
            // 
            this.toolStripButtonKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonKeyboard.Image")));
            this.toolStripButtonKeyboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonKeyboard.Name = "toolStripButtonKeyboard";
            this.toolStripButtonKeyboard.Size = new System.Drawing.Size(73, 43);
            this.toolStripButtonKeyboard.Text = "Keyboard";
            this.toolStripButtonKeyboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonKeyboard.ToolTipText = "Keyboard";
            this.toolStripButtonKeyboard.Visible = false;
            // 
            // toolStripButtonLogOut
            // 
            this.toolStripButtonLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonLogOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLogOut.Image")));
            this.toolStripButtonLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogOut.Name = "toolStripButtonLogOut";
            this.toolStripButtonLogOut.Size = new System.Drawing.Size(82, 43);
            this.toolStripButtonLogOut.Text = "Logout[F7]";
            this.toolStripButtonLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonLogOut.Click += new System.EventHandler(this.toolStripButtonLogOut_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1504, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1489, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDayPartsScannedHdr
            // 
            this.lblDayPartsScannedHdr.AutoSize = true;
            this.lblDayPartsScannedHdr.BackColor = System.Drawing.Color.White;
            this.lblDayPartsScannedHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayPartsScannedHdr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDayPartsScannedHdr.Location = new System.Drawing.Point(831, 24);
            this.lblDayPartsScannedHdr.Name = "lblDayPartsScannedHdr";
            this.lblDayPartsScannedHdr.Size = new System.Drawing.Size(139, 19);
            this.lblDayPartsScannedHdr.TabIndex = 4;
            this.lblDayPartsScannedHdr.Text = "Parts Scanned (Day)";
            // 
            // lblDayPartsScannedData
            // 
            this.lblDayPartsScannedData.AutoSize = true;
            this.lblDayPartsScannedData.BackColor = System.Drawing.Color.White;
            this.lblDayPartsScannedData.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayPartsScannedData.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblDayPartsScannedData.Location = new System.Drawing.Point(873, 1);
            this.lblDayPartsScannedData.Name = "lblDayPartsScannedData";
            this.lblDayPartsScannedData.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblDayPartsScannedData.Size = new System.Drawing.Size(20, 29);
            this.lblDayPartsScannedData.TabIndex = 5;
            this.lblDayPartsScannedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShiftHdr
            // 
            this.lblShiftHdr.AutoSize = true;
            this.lblShiftHdr.BackColor = System.Drawing.Color.White;
            this.lblShiftHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftHdr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblShiftHdr.Location = new System.Drawing.Point(1019, 24);
            this.lblShiftHdr.Name = "lblShiftHdr";
            this.lblShiftHdr.Size = new System.Drawing.Size(38, 19);
            this.lblShiftHdr.TabIndex = 6;
            this.lblShiftHdr.Text = "Shift";
            // 
            // lblShiftData
            // 
            this.lblShiftData.AutoSize = true;
            this.lblShiftData.BackColor = System.Drawing.Color.White;
            this.lblShiftData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftData.Location = new System.Drawing.Point(1013, 6);
            this.lblShiftData.Name = "lblShiftData";
            this.lblShiftData.Size = new System.Drawing.Size(0, 19);
            this.lblShiftData.TabIndex = 7;
            this.lblShiftData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLastSyncDateHdr
            // 
            this.lblLastSyncDateHdr.AutoSize = true;
            this.lblLastSyncDateHdr.BackColor = System.Drawing.Color.White;
            this.lblLastSyncDateHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSyncDateHdr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLastSyncDateHdr.Location = new System.Drawing.Point(1096, 24);
            this.lblLastSyncDateHdr.Name = "lblLastSyncDateHdr";
            this.lblLastSyncDateHdr.Size = new System.Drawing.Size(104, 19);
            this.lblLastSyncDateHdr.TabIndex = 8;
            this.lblLastSyncDateHdr.Text = "Last Sync Date";
            this.lblLastSyncDateHdr.Click += new System.EventHandler(this.lblLastSyncDateHdr_Click);
            // 
            // lblLastSyncDateData
            // 
            this.lblLastSyncDateData.AutoSize = true;
            this.lblLastSyncDateData.BackColor = System.Drawing.Color.White;
            this.lblLastSyncDateData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSyncDateData.Location = new System.Drawing.Point(1086, 6);
            this.lblLastSyncDateData.Name = "lblLastSyncDateData";
            this.lblLastSyncDateData.Size = new System.Drawing.Size(0, 19);
            this.lblLastSyncDateData.TabIndex = 9;
            // 
            // pnlStation
            // 
            this.pnlStation.BackColor = System.Drawing.Color.White;
            this.pnlStation.Controls.Add(this.pictureBox1);
            this.pnlStation.Controls.Add(this.lblStation);
            this.pnlStation.ForeColor = System.Drawing.Color.White;
            this.pnlStation.Location = new System.Drawing.Point(1224, 1);
            this.pnlStation.Name = "pnlStation";
            this.pnlStation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.pnlStation.Size = new System.Drawing.Size(199, 44);
            this.pnlStation.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.ForeColor = System.Drawing.Color.Black;
            this.lblStation.Location = new System.Drawing.Point(58, 7);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(0, 26);
            this.lblStation.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(990, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 44);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1079, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 44);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1218, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 44);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(803, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 44);
            this.panel4.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(628, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 44);
            this.panel5.TabIndex = 20;
            // 
            // lblShiftsPartsScannedHdr
            // 
            this.lblShiftsPartsScannedHdr.AutoSize = true;
            this.lblShiftsPartsScannedHdr.BackColor = System.Drawing.Color.White;
            this.lblShiftsPartsScannedHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftsPartsScannedHdr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblShiftsPartsScannedHdr.Location = new System.Drawing.Point(650, 24);
            this.lblShiftsPartsScannedHdr.Name = "lblShiftsPartsScannedHdr";
            this.lblShiftsPartsScannedHdr.Size = new System.Drawing.Size(143, 19);
            this.lblShiftsPartsScannedHdr.TabIndex = 19;
            this.lblShiftsPartsScannedHdr.Text = "Parts Scanned (Shift)";
            // 
            // lblShiftsPartsScannedData
            // 
            this.lblShiftsPartsScannedData.AutoSize = true;
            this.lblShiftsPartsScannedData.BackColor = System.Drawing.Color.White;
            this.lblShiftsPartsScannedData.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftsPartsScannedData.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblShiftsPartsScannedData.Location = new System.Drawing.Point(698, 1);
            this.lblShiftsPartsScannedData.Name = "lblShiftsPartsScannedData";
            this.lblShiftsPartsScannedData.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblShiftsPartsScannedData.Size = new System.Drawing.Size(20, 29);
            this.lblShiftsPartsScannedData.TabIndex = 21;
            this.lblShiftsPartsScannedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(168, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1326, 52);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
            // 
            // MDISPC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1504, 749);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblShiftsPartsScannedData);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblShiftsPartsScannedHdr);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlStation);
            this.Controls.Add(this.lblLastSyncDateData);
            this.Controls.Add(this.lblLastSyncDateHdr);
            this.Controls.Add(this.lblShiftData);
            this.Controls.Add(this.lblShiftHdr);
            this.Controls.Add(this.lblDayPartsScannedData);
            this.Controls.Add(this.lblDayPartsScannedHdr);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDISPC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1";
            this.Text = "QA/S SPC - Version : 2.1 Build 202208";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDISPC_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDISPC_FormClosed);
            this.Load += new System.EventHandler(this.MDISPC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MDISPC_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlStation.ResumeLayout(false);
            this.pnlStation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripButtonKeyboard;
        private System.Windows.Forms.ToolStripMenuItem currentCharacteristicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allCharacteristicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonEvent;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogOut;
        private System.Windows.Forms.Label lblDayPartsScannedHdr;
        private System.Windows.Forms.Label lblShiftHdr;
        private System.Windows.Forms.Label lblLastSyncDateHdr;
        public System.Windows.Forms.Label lblDayPartsScannedData;
        public System.Windows.Forms.Label lblShiftData;
        public System.Windows.Forms.Label lblLastSyncDateData;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel pnlStation;
        public System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblShiftsPartsScannedHdr;
        public System.Windows.Forms.Label lblShiftsPartsScannedData;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemovePartNo;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ToolStripButton toolStripButtonScan;
        public System.Windows.Forms.ToolStripButton toolStripButtonInspection;
        public System.Windows.Forms.ToolStripButton toolStripButtonModify;
        public System.Windows.Forms.ToolStripButton toolStripButtonCharts;
        public System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonRetake;
    }
}

