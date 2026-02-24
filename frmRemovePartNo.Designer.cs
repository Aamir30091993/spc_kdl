namespace SPC_KDL
{
    partial class frmRemovePartNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemovePartNo));
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.pnlModifyFooter = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPartNo = new System.Windows.Forms.ComboBox();
            this.lblPartNoModify = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlModifyHeader = new System.Windows.Forms.Panel();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlModifyFooter.SuspendLayout();
            this.pnlModifyHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownHeight = 150;
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.DropDownWidth = 75;
            this.cmbTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.IntegralHeight = false;
            this.cmbTemplate.Location = new System.Drawing.Point(96, 73);
            this.cmbTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(365, 27);
            this.cmbTemplate.TabIndex = 42;
            this.cmbTemplate.SelectionChangeCommitted += new System.EventHandler(this.cmbTemplate_SelectionChangeCommitted);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.Location = new System.Drawing.Point(7, 76);
            this.lblTemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(81, 19);
            this.lblTemplate.TabIndex = 52;
            this.lblTemplate.Text = "Template : ";
            // 
            // pnlModifyFooter
            // 
            this.pnlModifyFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlModifyFooter.Controls.Add(this.btnRemove);
            this.pnlModifyFooter.Controls.Add(this.button1);
            this.pnlModifyFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlModifyFooter.Location = new System.Drawing.Point(-4, 151);
            this.pnlModifyFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlModifyFooter.Name = "pnlModifyFooter";
            this.pnlModifyFooter.Size = new System.Drawing.Size(504, 47);
            this.pnlModifyFooter.TabIndex = 51;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(313, 6);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(72, 34);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(393, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.DropDownHeight = 200;
            this.cmbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartNo.DropDownWidth = 100;
            this.cmbPartNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.IntegralHeight = false;
            this.cmbPartNo.Location = new System.Drawing.Point(98, 116);
            this.cmbPartNo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(363, 27);
            this.cmbPartNo.TabIndex = 44;
            // 
            // lblPartNoModify
            // 
            this.lblPartNoModify.AutoSize = true;
            this.lblPartNoModify.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNoModify.Location = new System.Drawing.Point(6, 119);
            this.lblPartNoModify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartNoModify.Name = "lblPartNoModify";
            this.lblPartNoModify.Size = new System.Drawing.Size(73, 19);
            this.lblPartNoModify.TabIndex = 47;
            this.lblPartNoModify.Text = "Part No. : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = " • To remove a Part no from Inspection Queue by selecting \r\n    the Template and " +
    "Part No, and click on \"Remove\".\r\n";
            // 
            // pnlModifyHeader
            // 
            this.pnlModifyHeader.BackColor = System.Drawing.Color.White;
            this.pnlModifyHeader.Controls.Add(this.label1);
            this.pnlModifyHeader.Controls.Add(this.pbInfo);
            this.pnlModifyHeader.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlModifyHeader.Location = new System.Drawing.Point(3, 2);
            this.pnlModifyHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlModifyHeader.Name = "pnlModifyHeader";
            this.pnlModifyHeader.Size = new System.Drawing.Size(497, 63);
            this.pnlModifyHeader.TabIndex = 50;
            // 
            // pbInfo
            // 
            this.pbInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbInfo.BackgroundImage")));
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInfo.Location = new System.Drawing.Point(16, 12);
            this.pbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(49, 42);
            this.pbInfo.TabIndex = 0;
            this.pbInfo.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRemovePartNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 201);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.pnlModifyFooter);
            this.Controls.Add(this.cmbPartNo);
            this.Controls.Add(this.lblPartNoModify);
            this.Controls.Add(this.pnlModifyHeader);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRemovePartNo";
            this.Text = "Remove Part No";
            this.Activated += new System.EventHandler(this.frmRemovePartNo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRemovePartNo_FormClosed);
            this.Load += new System.EventHandler(this.frmRemovePartNo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRemovePartNo_KeyUp);
            this.pnlModifyFooter.ResumeLayout(false);
            this.pnlModifyHeader.ResumeLayout(false);
            this.pnlModifyHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Panel pnlModifyFooter;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbPartNo;
        private System.Windows.Forms.Label lblPartNoModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Panel pnlModifyHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}