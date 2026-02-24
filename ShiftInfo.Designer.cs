namespace SPC_KDL
{
    partial class frmShiftInfo
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.lblTokenNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlScanPartNoFooter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlScanPartNoFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(158, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(273, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtOperatorName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperatorName.Location = new System.Drawing.Point(158, 173);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(273, 27);
            this.txtOperatorName.TabIndex = 16;
            this.txtOperatorName.TextChanged += new System.EventHandler(this.txtOperatorName_TextChanged);
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownHeight = 100;
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.DropDownWidth = 75;
            this.cmbShift.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.IntegralHeight = false;
            this.cmbShift.Location = new System.Drawing.Point(158, 124);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(273, 27);
            this.cmbShift.TabIndex = 14;
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtTokenNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNo.Location = new System.Drawing.Point(158, 228);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(273, 27);
            this.txtTokenNo.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(182, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 34);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(21, 124);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(50, 19);
            this.lblShift.TabIndex = 20;
            this.lblShift.Text = "Shift : ";
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Location = new System.Drawing.Point(21, 176);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(121, 19);
            this.lblOperatorName.TabIndex = 21;
            this.lblOperatorName.Text = "Operator Name : ";
            // 
            // lblTokenNo
            // 
            this.lblTokenNo.AutoSize = true;
            this.lblTokenNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenNo.Location = new System.Drawing.Point(21, 231);
            this.lblTokenNo.Name = "lblTokenNo";
            this.lblTokenNo.Size = new System.Drawing.Size(80, 19);
            this.lblTokenNo.TabIndex = 22;
            this.lblTokenNo.Text = "Token No : ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(21, 79);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 19);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(291, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 34);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlScanPartNoFooter
            // 
            this.pnlScanPartNoFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlScanPartNoFooter.Controls.Add(this.btnSave);
            this.pnlScanPartNoFooter.Controls.Add(this.btnClear);
            this.pnlScanPartNoFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoFooter.Location = new System.Drawing.Point(0, 352);
            this.pnlScanPartNoFooter.Name = "pnlScanPartNoFooter";
            this.pnlScanPartNoFooter.Size = new System.Drawing.Size(447, 48);
            this.pnlScanPartNoFooter.TabIndex = 26;
            // 
            // frmShiftInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 406);
            this.Controls.Add(this.pnlScanPartNoFooter);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTokenNo);
            this.Controls.Add(this.lblOperatorName);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.txtTokenNo);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmShiftInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shift Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShiftInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmShiftInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlScanPartNoFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.Label lblTokenNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.TextBox txtOperatorName;
        public System.Windows.Forms.ComboBox cmbShift;
        public System.Windows.Forms.TextBox txtTokenNo;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel pnlScanPartNoFooter;
    }
}