namespace SPC_KDL
{
    partial class frmRetake
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
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblDash = new System.Windows.Forms.Label();
            this.lblChar = new System.Windows.Forms.Label();
            this.txtTemplateID = new System.Windows.Forms.TextBox();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.txtCharID = new System.Windows.Forms.TextBox();
            this.lblQuestionMark = new System.Windows.Forms.Label();
            this.txtCurrentCharCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg1.Location = new System.Drawing.Point(4, 3);
            this.lblMsg1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(175, 19);
            this.lblMsg1.TabIndex = 0;
            this.lblMsg1.Text = "Retake for characteristic";
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(311, 76);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(104, 34);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(419, 76);
            this.btnNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(104, 34);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(4, 34);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(53, 19);
            this.lblModel.TabIndex = 22;
            this.lblModel.Text = "Model";
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.Location = new System.Drawing.Point(64, 34);
            this.lblDash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(14, 19);
            this.lblDash.TabIndex = 23;
            this.lblDash.Text = "-";
            this.lblDash.Visible = false;
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChar.Location = new System.Drawing.Point(80, 34);
            this.lblChar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(40, 19);
            this.lblChar.TabIndex = 24;
            this.lblChar.Text = "Char";
            this.lblChar.Visible = false;
            // 
            // txtTemplateID
            // 
            this.txtTemplateID.Location = new System.Drawing.Point(311, 0);
            this.txtTemplateID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTemplateID.Name = "txtTemplateID";
            this.txtTemplateID.Size = new System.Drawing.Size(20, 27);
            this.txtTemplateID.TabIndex = 25;
            this.txtTemplateID.Visible = false;
            // 
            // txtMachineID
            // 
            this.txtMachineID.Location = new System.Drawing.Point(340, 0);
            this.txtMachineID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(20, 27);
            this.txtMachineID.TabIndex = 26;
            this.txtMachineID.Visible = false;
            // 
            // txtPartNo
            // 
            this.txtPartNo.Location = new System.Drawing.Point(369, 0);
            this.txtPartNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(20, 27);
            this.txtPartNo.TabIndex = 27;
            this.txtPartNo.Visible = false;
            // 
            // txtCharID
            // 
            this.txtCharID.Location = new System.Drawing.Point(399, 0);
            this.txtCharID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCharID.Name = "txtCharID";
            this.txtCharID.Size = new System.Drawing.Size(20, 27);
            this.txtCharID.TabIndex = 28;
            this.txtCharID.Visible = false;
            // 
            // lblQuestionMark
            // 
            this.lblQuestionMark.AutoSize = true;
            this.lblQuestionMark.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionMark.Location = new System.Drawing.Point(128, 34);
            this.lblQuestionMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionMark.Name = "lblQuestionMark";
            this.lblQuestionMark.Size = new System.Drawing.Size(16, 19);
            this.lblQuestionMark.TabIndex = 29;
            this.lblQuestionMark.Text = "?";
            this.lblQuestionMark.Visible = false;
            // 
            // txtCurrentCharCount
            // 
            this.txtCurrentCharCount.Location = new System.Drawing.Point(428, 0);
            this.txtCurrentCharCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrentCharCount.Name = "txtCurrentCharCount";
            this.txtCurrentCharCount.Size = new System.Drawing.Size(20, 27);
            this.txtCurrentCharCount.TabIndex = 30;
            this.txtCurrentCharCount.Visible = false;
            // 
            // frmRetake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 113);
            this.Controls.Add(this.txtCurrentCharCount);
            this.Controls.Add(this.lblQuestionMark);
            this.Controls.Add(this.txtCharID);
            this.Controls.Add(this.txtPartNo);
            this.Controls.Add(this.txtMachineID);
            this.Controls.Add(this.txtTemplateID);
            this.Controls.Add(this.lblChar);
            this.Controls.Add(this.lblDash);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblMsg1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetake";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove last observation";
            this.Activated += new System.EventHandler(this.frmRetake_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRetake_FormClosing);
            this.Load += new System.EventHandler(this.frmRetake_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRetake_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Label lblChar;
        private System.Windows.Forms.TextBox txtTemplateID;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.TextBox txtCharID;
        private System.Windows.Forms.Label lblQuestionMark;
        private System.Windows.Forms.TextBox txtCurrentCharCount;
    }
}