namespace SPC_KDL
{
    partial class frmSetSPCStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetSPCStation));
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.lblSPCStation = new System.Windows.Forms.Label();
            this.cmbSPCStation = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.lblMsg3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg1.Location = new System.Drawing.Point(6, 16);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(550, 19);
            this.lblMsg1.TabIndex = 0;
            this.lblMsg1.Text = "To Configure this SPC Terminal chose one of the SPC Station from the below list";
            // 
            // lblSPCStation
            // 
            this.lblSPCStation.AutoSize = true;
            this.lblSPCStation.Location = new System.Drawing.Point(6, 74);
            this.lblSPCStation.Name = "lblSPCStation";
            this.lblSPCStation.Size = new System.Drawing.Size(90, 19);
            this.lblSPCStation.TabIndex = 1;
            this.lblSPCStation.Text = "SPC Station :";
            // 
            // cmbSPCStation
            // 
            this.cmbSPCStation.DropDownHeight = 150;
            this.cmbSPCStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSPCStation.DropDownWidth = 100;
            this.cmbSPCStation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSPCStation.FormattingEnabled = true;
            this.cmbSPCStation.IntegralHeight = false;
            this.cmbSPCStation.Items.AddRange(new object[] {
            "SPC 1",
            "SPC 2",
            "SPC 3"});
            this.cmbSPCStation.Location = new System.Drawing.Point(121, 71);
            this.cmbSPCStation.Name = "cmbSPCStation";
            this.cmbSPCStation.Size = new System.Drawing.Size(240, 27);
            this.cmbSPCStation.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(157, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(262, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsg2
            // 
            this.lblMsg2.AutoSize = true;
            this.lblMsg2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg2.ForeColor = System.Drawing.Color.Red;
            this.lblMsg2.Location = new System.Drawing.Point(6, 214);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(460, 19);
            this.lblMsg2.TabIndex = 5;
            this.lblMsg2.Text = "Note :- In case the SPC Station is not found in the list then use the";
            // 
            // lblMsg3
            // 
            this.lblMsg3.AutoSize = true;
            this.lblMsg3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg3.ForeColor = System.Drawing.Color.Red;
            this.lblMsg3.Location = new System.Drawing.Point(56, 229);
            this.lblMsg3.Name = "lblMsg3";
            this.lblMsg3.Size = new System.Drawing.Size(278, 19);
            this.lblMsg3.TabIndex = 6;
            this.lblMsg3.Text = "enterprise application to add the same.";
            // 
            // frmSetSPCStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 256);
            this.Controls.Add(this.lblMsg3);
            this.Controls.Add(this.lblMsg2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbSPCStation);
            this.Controls.Add(this.lblSPCStation);
            this.Controls.Add(this.lblMsg1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetSPCStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QA/S SPC Station";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetSPCStation_FormClosed);
            this.Load += new System.EventHandler(this.frmSetSPCStation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Label lblSPCStation;
        private System.Windows.Forms.ComboBox cmbSPCStation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMsg2;
        private System.Windows.Forms.Label lblMsg3;
    }
}