namespace SPC_KDL
{
    partial class frmScanPartNo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanPartNo));
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.cmbMachineNo = new System.Windows.Forms.ComboBox();
            this.lblMachineNo = new System.Windows.Forms.Label();
            this.cmbPalletNo = new System.Windows.Forms.ComboBox();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.lblPartNo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlScanPartNoHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pnlScanPartNoFooter = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblModelNo = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.lblDotSpec = new System.Windows.Forms.Label();
            this.cmbDotSpec = new System.Windows.Forms.ComboBox();
            this.txtModelSAPNo = new System.Windows.Forms.TextBox();
            this.lblModelSAPNo = new System.Windows.Forms.Label();
            this.cmbCastingSupplierwise = new System.Windows.Forms.ComboBox();
            this.lblCastingSupplierwise = new System.Windows.Forms.Label();
            this.cmbSemifinishSupplierwise = new System.Windows.Forms.ComboBox();
            this.lblSemifinishSupplierwise = new System.Windows.Forms.Label();
            this.pnlScanPartNoHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.pnlScanPartNoFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEvent
            // 
            this.cmbEvent.DropDownHeight = 150;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.DropDownWidth = 75;
            this.cmbEvent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.IntegralHeight = false;
            this.cmbEvent.Location = new System.Drawing.Point(201, 174);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(273, 27);
            this.cmbEvent.TabIndex = 7;
            this.cmbEvent.Visible = false;
            this.cmbEvent.SelectionChangeCommitted += new System.EventHandler(this.cmbEvent_SelectionChangeCommitted);
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownHeight = 150;
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.DropDownWidth = 75;
            this.cmbTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.IntegralHeight = false;
            this.cmbTemplate.Location = new System.Drawing.Point(201, 131);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(273, 27);
            this.cmbTemplate.TabIndex = 5;
            this.cmbTemplate.SelectionChangeCommitted += new System.EventHandler(this.cmbTemplate_SelectionChangeCommitted);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.Location = new System.Drawing.Point(11, 131);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(81, 19);
            this.lblTemplate.TabIndex = 4;
            this.lblTemplate.Text = "Template : ";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownHeight = 100;
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.DropDownWidth = 75;
            this.cmbShift.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.IntegralHeight = false;
            this.cmbShift.Location = new System.Drawing.Point(201, 174);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(273, 27);
            this.cmbShift.TabIndex = 9;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(12, 174);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(50, 19);
            this.lblShift.TabIndex = 8;
            this.lblShift.Text = "Shift : ";
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Location = new System.Drawing.Point(12, 212);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(121, 19);
            this.lblOperatorName.TabIndex = 10;
            this.lblOperatorName.Text = "Operator Name : ";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtOperatorName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperatorName.Location = new System.Drawing.Point(201, 212);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(273, 27);
            this.txtOperatorName.TabIndex = 11;
            this.txtOperatorName.TextChanged += new System.EventHandler(this.txtOperatorName_TextChanged);
            // 
            // cmbMachineNo
            // 
            this.cmbMachineNo.DropDownHeight = 150;
            this.cmbMachineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineNo.DropDownWidth = 75;
            this.cmbMachineNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachineNo.FormattingEnabled = true;
            this.cmbMachineNo.IntegralHeight = false;
            this.cmbMachineNo.Location = new System.Drawing.Point(201, 255);
            this.cmbMachineNo.Name = "cmbMachineNo";
            this.cmbMachineNo.Size = new System.Drawing.Size(273, 27);
            this.cmbMachineNo.TabIndex = 13;
            this.cmbMachineNo.SelectionChangeCommitted += new System.EventHandler(this.cmbMachineNo_SelectionChangeCommitted);
            // 
            // lblMachineNo
            // 
            this.lblMachineNo.AutoSize = true;
            this.lblMachineNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineNo.Location = new System.Drawing.Point(12, 255);
            this.lblMachineNo.Name = "lblMachineNo";
            this.lblMachineNo.Size = new System.Drawing.Size(99, 19);
            this.lblMachineNo.TabIndex = 12;
            this.lblMachineNo.Text = "Machine No : ";
            // 
            // cmbPalletNo
            // 
            this.cmbPalletNo.DropDownHeight = 100;
            this.cmbPalletNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPalletNo.DropDownWidth = 75;
            this.cmbPalletNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPalletNo.FormattingEnabled = true;
            this.cmbPalletNo.IntegralHeight = false;
            this.cmbPalletNo.Location = new System.Drawing.Point(201, 298);
            this.cmbPalletNo.Name = "cmbPalletNo";
            this.cmbPalletNo.Size = new System.Drawing.Size(273, 27);
            this.cmbPalletNo.TabIndex = 15;
            this.cmbPalletNo.SelectionChangeCommitted += new System.EventHandler(this.cmbPalletNo_SelectionChangeCommitted);
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.AutoSize = true;
            this.lblPalletNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNo.Location = new System.Drawing.Point(12, 298);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(80, 19);
            this.lblPalletNo.TabIndex = 14;
            this.lblPalletNo.Text = "Pallet No : ";
            // 
            // txtPartNo
            // 
            this.txtPartNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtPartNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNo.Location = new System.Drawing.Point(201, 341);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(273, 27);
            this.txtPartNo.TabIndex = 16;
            this.txtPartNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartNo_KeyDown);
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(12, 341);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(69, 19);
            this.lblPartNo.TabIndex = 17;
            this.lblPartNo.Text = "Part No : ";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(234, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 34);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(340, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 34);
            this.button1.TabIndex = 19;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlScanPartNoHeader
            // 
            this.pnlScanPartNoHeader.BackColor = System.Drawing.Color.White;
            this.pnlScanPartNoHeader.Controls.Add(this.label1);
            this.pnlScanPartNoHeader.Controls.Add(this.pbInfo);
            this.pnlScanPartNoHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoHeader.Location = new System.Drawing.Point(-4, 1);
            this.pnlScanPartNoHeader.Name = "pnlScanPartNoHeader";
            this.pnlScanPartNoHeader.Size = new System.Drawing.Size(502, 85);
            this.pnlScanPartNoHeader.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "• To select Template, Event, Shift will be default set , \r\n   enter Operator Name" +
    ", select Machine No, Pallet No.\r\n• To Scan Part No and Model No will be extracte" +
    "d from it.\r\n ";
            // 
            // pbInfo
            // 
            this.pbInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbInfo.BackgroundImage")));
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInfo.Location = new System.Drawing.Point(12, 8);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(49, 42);
            this.pbInfo.TabIndex = 0;
            this.pbInfo.TabStop = false;
            // 
            // pnlScanPartNoFooter
            // 
            this.pnlScanPartNoFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlScanPartNoFooter.Controls.Add(this.btnSave);
            this.pnlScanPartNoFooter.Controls.Add(this.button1);
            this.pnlScanPartNoFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoFooter.Location = new System.Drawing.Point(-4, 556);
            this.pnlScanPartNoFooter.Name = "pnlScanPartNoFooter";
            this.pnlScanPartNoFooter.Size = new System.Drawing.Size(502, 48);
            this.pnlScanPartNoFooter.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // lblModelNo
            // 
            this.lblModelNo.AutoSize = true;
            this.lblModelNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelNo.Location = new System.Drawing.Point(12, 381);
            this.lblModelNo.Name = "lblModelNo";
            this.lblModelNo.Size = new System.Drawing.Size(84, 19);
            this.lblModelNo.TabIndex = 104;
            this.lblModelNo.Text = "Model No : ";
            // 
            // txtModelNo
            // 
            this.txtModelNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtModelNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelNo.Location = new System.Drawing.Point(201, 381);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(273, 27);
            this.txtModelNo.TabIndex = 17;
            // 
            // lblDotSpec
            // 
            this.lblDotSpec.AutoSize = true;
            this.lblDotSpec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDotSpec.Location = new System.Drawing.Point(12, 93);
            this.lblDotSpec.Name = "lblDotSpec";
            this.lblDotSpec.Size = new System.Drawing.Size(78, 19);
            this.lblDotSpec.TabIndex = 105;
            this.lblDotSpec.Text = "Dot Spec : ";
            // 
            // cmbDotSpec
            // 
            this.cmbDotSpec.DropDownHeight = 150;
            this.cmbDotSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDotSpec.DropDownWidth = 75;
            this.cmbDotSpec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDotSpec.FormattingEnabled = true;
            this.cmbDotSpec.IntegralHeight = false;
            this.cmbDotSpec.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7"});
            this.cmbDotSpec.Location = new System.Drawing.Point(201, 93);
            this.cmbDotSpec.Name = "cmbDotSpec";
            this.cmbDotSpec.Size = new System.Drawing.Size(273, 27);
            this.cmbDotSpec.TabIndex = 106;
            this.cmbDotSpec.SelectionChangeCommitted += new System.EventHandler(this.cmbDotSpec_SelectionChangeCommitted);
            // 
            // txtModelSAPNo
            // 
            this.txtModelSAPNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtModelSAPNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelSAPNo.Location = new System.Drawing.Point(201, 423);
            this.txtModelSAPNo.Name = "txtModelSAPNo";
            this.txtModelSAPNo.Size = new System.Drawing.Size(273, 27);
            this.txtModelSAPNo.TabIndex = 107;
            this.txtModelSAPNo.Leave += new System.EventHandler(this.txtModelSAPNo_Leave);
            // 
            // lblModelSAPNo
            // 
            this.lblModelSAPNo.AutoSize = true;
            this.lblModelSAPNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelSAPNo.Location = new System.Drawing.Point(12, 423);
            this.lblModelSAPNo.Name = "lblModelSAPNo";
            this.lblModelSAPNo.Size = new System.Drawing.Size(108, 19);
            this.lblModelSAPNo.TabIndex = 108;
            this.lblModelSAPNo.Text = "Model SAP No :";
            // 
            // cmbCastingSupplierwise
            // 
            this.cmbCastingSupplierwise.DropDownHeight = 150;
            this.cmbCastingSupplierwise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCastingSupplierwise.DropDownWidth = 75;
            this.cmbCastingSupplierwise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCastingSupplierwise.FormattingEnabled = true;
            this.cmbCastingSupplierwise.IntegralHeight = false;
            this.cmbCastingSupplierwise.Location = new System.Drawing.Point(201, 463);
            this.cmbCastingSupplierwise.Name = "cmbCastingSupplierwise";
            this.cmbCastingSupplierwise.Size = new System.Drawing.Size(273, 27);
            this.cmbCastingSupplierwise.TabIndex = 110;
            this.cmbCastingSupplierwise.SelectionChangeCommitted += new System.EventHandler(this.cmbCastingSupplierwise_SelectionChangeCommitted);
            this.cmbCastingSupplierwise.Leave += new System.EventHandler(this.cmbCastingSupplierwise_Leave);
            // 
            // lblCastingSupplierwise
            // 
            this.lblCastingSupplierwise.AutoSize = true;
            this.lblCastingSupplierwise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCastingSupplierwise.Location = new System.Drawing.Point(12, 466);
            this.lblCastingSupplierwise.Name = "lblCastingSupplierwise";
            this.lblCastingSupplierwise.Size = new System.Drawing.Size(160, 19);
            this.lblCastingSupplierwise.TabIndex = 109;
            this.lblCastingSupplierwise.Text = "Casting Supplier wise : ";
            // 
            // cmbSemifinishSupplierwise
            // 
            this.cmbSemifinishSupplierwise.DropDownHeight = 150;
            this.cmbSemifinishSupplierwise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemifinishSupplierwise.DropDownWidth = 75;
            this.cmbSemifinishSupplierwise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemifinishSupplierwise.FormattingEnabled = true;
            this.cmbSemifinishSupplierwise.IntegralHeight = false;
            this.cmbSemifinishSupplierwise.Location = new System.Drawing.Point(201, 505);
            this.cmbSemifinishSupplierwise.Name = "cmbSemifinishSupplierwise";
            this.cmbSemifinishSupplierwise.Size = new System.Drawing.Size(273, 27);
            this.cmbSemifinishSupplierwise.TabIndex = 112;
            this.cmbSemifinishSupplierwise.Leave += new System.EventHandler(this.cmbSemifinishSupplierwise_Leave);
            // 
            // lblSemifinishSupplierwise
            // 
            this.lblSemifinishSupplierwise.AutoSize = true;
            this.lblSemifinishSupplierwise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemifinishSupplierwise.Location = new System.Drawing.Point(12, 508);
            this.lblSemifinishSupplierwise.Name = "lblSemifinishSupplierwise";
            this.lblSemifinishSupplierwise.Size = new System.Drawing.Size(182, 19);
            this.lblSemifinishSupplierwise.TabIndex = 111;
            this.lblSemifinishSupplierwise.Text = "Semi-finish Supplier wise : ";
            // 
            // frmScanPartNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 606);
            this.Controls.Add(this.cmbSemifinishSupplierwise);
            this.Controls.Add(this.lblSemifinishSupplierwise);
            this.Controls.Add(this.cmbCastingSupplierwise);
            this.Controls.Add(this.lblCastingSupplierwise);
            this.Controls.Add(this.txtModelSAPNo);
            this.Controls.Add(this.lblModelSAPNo);
            this.Controls.Add(this.cmbDotSpec);
            this.Controls.Add(this.lblDotSpec);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.lblModelNo);
            this.Controls.Add(this.pnlScanPartNoFooter);
            this.Controls.Add(this.pnlScanPartNoHeader);
            this.Controls.Add(this.lblPartNo);
            this.Controls.Add(this.txtPartNo);
            this.Controls.Add(this.cmbPalletNo);
            this.Controls.Add(this.lblPalletNo);
            this.Controls.Add(this.cmbMachineNo);
            this.Controls.Add(this.lblMachineNo);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.lblOperatorName);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cmbEvent);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanPartNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan Part No";
            this.Activated += new System.EventHandler(this.frmScanPartNo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScanPartNo_FormClosed);
            this.Load += new System.EventHandler(this.frmScanPartNo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmScanPartNo_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmScanPartNo_KeyUp);
            this.pnlScanPartNoHeader.ResumeLayout(false);
            this.pnlScanPartNoHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.pnlScanPartNoFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.Label lblMachineNo;
        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlScanPartNoHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Panel pnlScanPartNoFooter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblModelNo;
        private System.Windows.Forms.Label lblDotSpec;
        public System.Windows.Forms.ComboBox cmbTemplate;
        public System.Windows.Forms.ComboBox cmbMachineNo;
        public System.Windows.Forms.ComboBox cmbPalletNo;
        public System.Windows.Forms.TextBox txtPartNo;
        public System.Windows.Forms.TextBox txtModelNo;
        public System.Windows.Forms.ComboBox cmbDotSpec;
        public System.Windows.Forms.ComboBox cmbShift;
        public System.Windows.Forms.TextBox txtOperatorName;
        public System.Windows.Forms.ComboBox cmbSemifinishSupplierwise;
        private System.Windows.Forms.Label lblSemifinishSupplierwise;
        public System.Windows.Forms.ComboBox cmbCastingSupplierwise;
        private System.Windows.Forms.Label lblCastingSupplierwise;
        public System.Windows.Forms.TextBox txtModelSAPNo;
        private System.Windows.Forms.Label lblModelSAPNo;
    }
}