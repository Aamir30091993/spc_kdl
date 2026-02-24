namespace SPC_KDL
{
    partial class frmModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModify));
            this.pnlModifyFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlModifyHeader = new System.Windows.Forms.Panel();
            this.cmbMachineNo = new System.Windows.Forms.ComboBox();
            this.lblMachineNo = new System.Windows.Forms.Label();
            this.cmbCharacteristics = new System.Windows.Forms.ComboBox();
            this.lblCharacteristics = new System.Windows.Forms.Label();
            this.cmbPartNo = new System.Windows.Forms.ComboBox();
            this.lblPartNoModify = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.lblReading = new System.Windows.Forms.Label();
            this.txtReading = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pnlModifyFooter.SuspendLayout();
            this.pnlModifyHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlModifyFooter
            // 
            this.pnlModifyFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlModifyFooter.Controls.Add(this.btnSave);
            this.pnlModifyFooter.Controls.Add(this.button1);
            this.pnlModifyFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlModifyFooter.Location = new System.Drawing.Point(-1, 306);
            this.pnlModifyFooter.Name = "pnlModifyFooter";
            this.pnlModifyFooter.Size = new System.Drawing.Size(444, 49);
            this.pnlModifyFooter.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(259, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Modify";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(337, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlModifyHeader
            // 
            this.pnlModifyHeader.BackColor = System.Drawing.Color.White;
            this.pnlModifyHeader.Controls.Add(this.label1);
            this.pnlModifyHeader.Controls.Add(this.pbInfo);
            this.pnlModifyHeader.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlModifyHeader.Location = new System.Drawing.Point(-1, 0);
            this.pnlModifyHeader.Name = "pnlModifyHeader";
            this.pnlModifyHeader.Size = new System.Drawing.Size(444, 96);
            this.pnlModifyHeader.TabIndex = 36;
            // 
            // cmbMachineNo
            // 
            this.cmbMachineNo.DropDownHeight = 150;
            this.cmbMachineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineNo.DropDownWidth = 75;
            this.cmbMachineNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachineNo.FormattingEnabled = true;
            this.cmbMachineNo.IntegralHeight = false;
            this.cmbMachineNo.Location = new System.Drawing.Point(135, 143);
            this.cmbMachineNo.Name = "cmbMachineNo";
            this.cmbMachineNo.Size = new System.Drawing.Size(273, 27);
            this.cmbMachineNo.TabIndex = 2;
            this.cmbMachineNo.SelectionChangeCommitted += new System.EventHandler(this.cmbMachineNo_SelectionChangeCommitted);
            // 
            // lblMachineNo
            // 
            this.lblMachineNo.AutoSize = true;
            this.lblMachineNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineNo.Location = new System.Drawing.Point(15, 146);
            this.lblMachineNo.Name = "lblMachineNo";
            this.lblMachineNo.Size = new System.Drawing.Size(91, 19);
            this.lblMachineNo.TabIndex = 30;
            this.lblMachineNo.Text = "Machine No:";
            // 
            // cmbCharacteristics
            // 
            this.cmbCharacteristics.DropDownHeight = 200;
            this.cmbCharacteristics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharacteristics.DropDownWidth = 200;
            this.cmbCharacteristics.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCharacteristics.FormattingEnabled = true;
            this.cmbCharacteristics.IntegralHeight = false;
            this.cmbCharacteristics.Location = new System.Drawing.Point(135, 228);
            this.cmbCharacteristics.Name = "cmbCharacteristics";
            this.cmbCharacteristics.Size = new System.Drawing.Size(273, 27);
            this.cmbCharacteristics.TabIndex = 4;
            this.cmbCharacteristics.SelectionChangeCommitted += new System.EventHandler(this.cmbCharacteristics_SelectionChangeCommitted);
            // 
            // lblCharacteristics
            // 
            this.lblCharacteristics.AutoSize = true;
            this.lblCharacteristics.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacteristics.Location = new System.Drawing.Point(15, 231);
            this.lblCharacteristics.Name = "lblCharacteristics";
            this.lblCharacteristics.Size = new System.Drawing.Size(118, 19);
            this.lblCharacteristics.TabIndex = 24;
            this.lblCharacteristics.Text = "Characteristics : ";
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.DropDownHeight = 200;
            this.cmbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartNo.DropDownWidth = 100;
            this.cmbPartNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.IntegralHeight = false;
            this.cmbPartNo.Location = new System.Drawing.Point(135, 185);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(273, 27);
            this.cmbPartNo.TabIndex = 3;
            this.cmbPartNo.SelectionChangeCommitted += new System.EventHandler(this.cmbPartNo_SelectionChangeCommitted);
            // 
            // lblPartNoModify
            // 
            this.lblPartNoModify.AutoSize = true;
            this.lblPartNoModify.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNoModify.Location = new System.Drawing.Point(15, 188);
            this.lblPartNoModify.Name = "lblPartNoModify";
            this.lblPartNoModify.Size = new System.Drawing.Size(69, 19);
            this.lblPartNoModify.TabIndex = 22;
            this.lblPartNoModify.Text = "Part No : ";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownHeight = 150;
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.DropDownWidth = 75;
            this.cmbTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.IntegralHeight = false;
            this.cmbTemplate.Location = new System.Drawing.Point(135, 102);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(275, 27);
            this.cmbTemplate.TabIndex = 1;
            this.cmbTemplate.SelectionChangeCommitted += new System.EventHandler(this.cmbTemplate_SelectionChangeCommitted);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.Location = new System.Drawing.Point(15, 105);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(81, 19);
            this.lblTemplate.TabIndex = 38;
            this.lblTemplate.Text = "Template : ";
            // 
            // lblReading
            // 
            this.lblReading.AutoSize = true;
            this.lblReading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReading.Location = new System.Drawing.Point(15, 274);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(74, 19);
            this.lblReading.TabIndex = 41;
            this.lblReading.Text = "Reading : ";
            // 
            // txtReading
            // 
            this.txtReading.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtReading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReading.Location = new System.Drawing.Point(135, 271);
            this.txtReading.Name = "txtReading";
            this.txtReading.Size = new System.Drawing.Size(273, 27);
            this.txtReading.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 76);
            this.label1.TabIndex = 2;
            this.label1.Text = " • To modify an existing reading by selecting Template, \r\n    Machine No, Part No" +
    ", Characteristics \r\n  • Enter reading to change the one  required and \r\n     mod" +
    "ify the value.";
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
            // frmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 356);
            this.Controls.Add(this.lblReading);
            this.Controls.Add(this.txtReading);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.pnlModifyFooter);
            this.Controls.Add(this.pnlModifyHeader);
            this.Controls.Add(this.cmbMachineNo);
            this.Controls.Add(this.lblMachineNo);
            this.Controls.Add(this.cmbCharacteristics);
            this.Controls.Add(this.lblCharacteristics);
            this.Controls.Add(this.cmbPartNo);
            this.Controls.Add(this.lblPartNoModify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify";
            this.Activated += new System.EventHandler(this.frmModify_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModify_FormClosing);
            this.Load += new System.EventHandler(this.frmModify_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmModify_KeyUp);
            this.pnlModifyFooter.ResumeLayout(false);
            this.pnlModifyHeader.ResumeLayout(false);
            this.pnlModifyHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlModifyFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlModifyHeader;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.ComboBox cmbMachineNo;
        private System.Windows.Forms.Label lblMachineNo;
        private System.Windows.Forms.ComboBox cmbCharacteristics;
        private System.Windows.Forms.Label lblCharacteristics;
        private System.Windows.Forms.ComboBox cmbPartNo;
        private System.Windows.Forms.Label lblPartNoModify;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.TextBox txtReading;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
    }
}