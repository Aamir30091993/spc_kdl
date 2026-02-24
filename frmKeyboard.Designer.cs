namespace SPC_KDL
{
    partial class frmKeyboard
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
            this.lblPartKeyboard = new System.Windows.Forms.Label();
            this.txtPartKeyboard = new System.Windows.Forms.TextBox();
            this.lblCharacteristicKeyboard = new System.Windows.Forms.Label();
            this.txtCharacteristicKeyboard = new System.Windows.Forms.TextBox();
            this.lblValueKeyboard = new System.Windows.Forms.Label();
            this.txtValueKeyboard = new System.Windows.Forms.TextBox();
            this.btnOKKeyboard = new System.Windows.Forms.Button();
            this.btnCloseKeyboard = new System.Windows.Forms.Button();
            this.txtcurrentCharCount = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUTL = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblLTL = new System.Windows.Forms.Label();
            this.txtUTL = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.txtLTL = new System.Windows.Forms.TextBox();
            this.pnlScanPartNoFooter = new System.Windows.Forms.Panel();
            this.chkMasterSize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlScanPartNoFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPartKeyboard
            // 
            this.lblPartKeyboard.AutoSize = true;
            this.lblPartKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartKeyboard.Location = new System.Drawing.Point(6, 49);
            this.lblPartKeyboard.Name = "lblPartKeyboard";
            this.lblPartKeyboard.Size = new System.Drawing.Size(43, 19);
            this.lblPartKeyboard.TabIndex = 0;
            this.lblPartKeyboard.Text = "Part :";
            this.lblPartKeyboard.Click += new System.EventHandler(this.lblPartKeyboard_Click);
            // 
            // txtPartKeyboard
            // 
            this.txtPartKeyboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPartKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartKeyboard.Location = new System.Drawing.Point(115, 49);
            this.txtPartKeyboard.Name = "txtPartKeyboard";
            this.txtPartKeyboard.ReadOnly = true;
            this.txtPartKeyboard.Size = new System.Drawing.Size(270, 20);
            this.txtPartKeyboard.TabIndex = 4;
            // 
            // lblCharacteristicKeyboard
            // 
            this.lblCharacteristicKeyboard.AutoSize = true;
            this.lblCharacteristicKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacteristicKeyboard.Location = new System.Drawing.Point(6, 82);
            this.lblCharacteristicKeyboard.Name = "lblCharacteristicKeyboard";
            this.lblCharacteristicKeyboard.Size = new System.Drawing.Size(111, 19);
            this.lblCharacteristicKeyboard.TabIndex = 2;
            this.lblCharacteristicKeyboard.Text = "Characteristic : ";
            // 
            // txtCharacteristicKeyboard
            // 
            this.txtCharacteristicKeyboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCharacteristicKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharacteristicKeyboard.Location = new System.Drawing.Point(115, 82);
            this.txtCharacteristicKeyboard.Name = "txtCharacteristicKeyboard";
            this.txtCharacteristicKeyboard.ReadOnly = true;
            this.txtCharacteristicKeyboard.Size = new System.Drawing.Size(270, 20);
            this.txtCharacteristicKeyboard.TabIndex = 5;
            // 
            // lblValueKeyboard
            // 
            this.lblValueKeyboard.AutoSize = true;
            this.lblValueKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueKeyboard.Location = new System.Drawing.Point(6, 118);
            this.lblValueKeyboard.Name = "lblValueKeyboard";
            this.lblValueKeyboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValueKeyboard.Size = new System.Drawing.Size(57, 19);
            this.lblValueKeyboard.TabIndex = 5;
            this.lblValueKeyboard.Text = "Value : ";
            // 
            // txtValueKeyboard
            // 
            this.txtValueKeyboard.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtValueKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueKeyboard.Location = new System.Drawing.Point(115, 118);
            this.txtValueKeyboard.Name = "txtValueKeyboard";
            this.txtValueKeyboard.Size = new System.Drawing.Size(267, 27);
            this.txtValueKeyboard.TabIndex = 1;
            this.txtValueKeyboard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValueKeyboard_KeyDown);
            this.txtValueKeyboard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueKeyboard_KeyPress);
            // 
            // btnOKKeyboard
            // 
            this.btnOKKeyboard.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKKeyboard.Location = new System.Drawing.Point(371, 9);
            this.btnOKKeyboard.Name = "btnOKKeyboard";
            this.btnOKKeyboard.Size = new System.Drawing.Size(75, 27);
            this.btnOKKeyboard.TabIndex = 2;
            this.btnOKKeyboard.Text = "OK";
            this.btnOKKeyboard.UseVisualStyleBackColor = true;
            this.btnOKKeyboard.Click += new System.EventHandler(this.btnOKKeyboard_Click);
            // 
            // btnCloseKeyboard
            // 
            this.btnCloseKeyboard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseKeyboard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseKeyboard.Location = new System.Drawing.Point(447, 9);
            this.btnCloseKeyboard.Name = "btnCloseKeyboard";
            this.btnCloseKeyboard.Size = new System.Drawing.Size(75, 27);
            this.btnCloseKeyboard.TabIndex = 3;
            this.btnCloseKeyboard.Text = "Close";
            this.btnCloseKeyboard.UseVisualStyleBackColor = true;
            this.btnCloseKeyboard.Click += new System.EventHandler(this.btnCloseKeyboard_Click);
            // 
            // txtcurrentCharCount
            // 
            this.txtcurrentCharCount.Location = new System.Drawing.Point(3, 148);
            this.txtcurrentCharCount.Name = "txtcurrentCharCount";
            this.txtcurrentCharCount.Size = new System.Drawing.Size(10, 21);
            this.txtcurrentCharCount.TabIndex = 9;
            this.txtcurrentCharCount.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // lblUTL
            // 
            this.lblUTL.AutoSize = true;
            this.lblUTL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTL.Location = new System.Drawing.Point(392, 49);
            this.lblUTL.Name = "lblUTL";
            this.lblUTL.Size = new System.Drawing.Size(42, 19);
            this.lblUTL.TabIndex = 10;
            this.lblUTL.Text = "UTL :";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(391, 82);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(58, 19);
            this.lblTarget.TabIndex = 11;
            this.lblTarget.Text = "Target :";
            // 
            // lblLTL
            // 
            this.lblLTL.AutoSize = true;
            this.lblLTL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLTL.Location = new System.Drawing.Point(392, 119);
            this.lblLTL.Name = "lblLTL";
            this.lblLTL.Size = new System.Drawing.Size(38, 19);
            this.lblLTL.TabIndex = 12;
            this.lblLTL.Text = "LTL :";
            // 
            // txtUTL
            // 
            this.txtUTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUTL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUTL.Location = new System.Drawing.Point(456, 49);
            this.txtUTL.Name = "txtUTL";
            this.txtUTL.ReadOnly = true;
            this.txtUTL.Size = new System.Drawing.Size(69, 20);
            this.txtUTL.TabIndex = 13;
            // 
            // txtTarget
            // 
            this.txtTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarget.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarget.Location = new System.Drawing.Point(456, 82);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ReadOnly = true;
            this.txtTarget.Size = new System.Drawing.Size(69, 20);
            this.txtTarget.TabIndex = 14;
            // 
            // txtLTL
            // 
            this.txtLTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLTL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLTL.Location = new System.Drawing.Point(456, 117);
            this.txtLTL.Name = "txtLTL";
            this.txtLTL.ReadOnly = true;
            this.txtLTL.Size = new System.Drawing.Size(69, 20);
            this.txtLTL.TabIndex = 15;
            // 
            // pnlScanPartNoFooter
            // 
            this.pnlScanPartNoFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlScanPartNoFooter.Controls.Add(this.btnCloseKeyboard);
            this.pnlScanPartNoFooter.Controls.Add(this.btnOKKeyboard);
            this.pnlScanPartNoFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoFooter.Location = new System.Drawing.Point(3, 151);
            this.pnlScanPartNoFooter.Name = "pnlScanPartNoFooter";
            this.pnlScanPartNoFooter.Size = new System.Drawing.Size(563, 47);
            this.pnlScanPartNoFooter.TabIndex = 23;
            // 
            // chkMasterSize
            // 
            this.chkMasterSize.AutoSize = true;
            this.chkMasterSize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMasterSize.Location = new System.Drawing.Point(10, 10);
            this.chkMasterSize.Name = "chkMasterSize";
            this.chkMasterSize.Size = new System.Drawing.Size(103, 23);
            this.chkMasterSize.TabIndex = 39;
            this.chkMasterSize.Text = "Master Size";
            this.chkMasterSize.UseVisualStyleBackColor = true;
            // 
            // frmKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 212);
            this.Controls.Add(this.chkMasterSize);
            this.Controls.Add(this.pnlScanPartNoFooter);
            this.Controls.Add(this.txtLTL);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtUTL);
            this.Controls.Add(this.lblLTL);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblUTL);
            this.Controls.Add(this.txtcurrentCharCount);
            this.Controls.Add(this.txtValueKeyboard);
            this.Controls.Add(this.lblValueKeyboard);
            this.Controls.Add(this.txtCharacteristicKeyboard);
            this.Controls.Add(this.lblCharacteristicKeyboard);
            this.Controls.Add(this.txtPartKeyboard);
            this.Controls.Add(this.lblPartKeyboard);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKeyboard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKeyboard_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmKeyboard_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlScanPartNoFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPartKeyboard;
        private System.Windows.Forms.TextBox txtPartKeyboard;
        private System.Windows.Forms.Label lblCharacteristicKeyboard;
        private System.Windows.Forms.TextBox txtCharacteristicKeyboard;
        private System.Windows.Forms.Label lblValueKeyboard;
        private System.Windows.Forms.TextBox txtValueKeyboard;
        private System.Windows.Forms.Button btnOKKeyboard;
        private System.Windows.Forms.Button btnCloseKeyboard;
        private System.Windows.Forms.TextBox txtcurrentCharCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblLTL;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblUTL;
        private System.Windows.Forms.TextBox txtLTL;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.TextBox txtUTL;
        private System.Windows.Forms.Panel pnlScanPartNoFooter;
        public System.Windows.Forms.CheckBox chkMasterSize;
    }
}