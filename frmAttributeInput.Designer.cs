namespace SPC_KDL
{
    partial class frmAttributeInput
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
            this.lblPartAttribute = new System.Windows.Forms.Label();
            this.txtPartAttribute = new System.Windows.Forms.TextBox();
            this.lblObsAttribute = new System.Windows.Forms.Label();
            this.txtObsAttribute = new System.Windows.Forms.TextBox();
            this.lblAtrribute = new System.Windows.Forms.Label();
            this.txtAttribute = new System.Windows.Forms.TextBox();
            this.lblDefectsAttribute = new System.Windows.Forms.Label();
            this.cmbDefectsAttribute = new System.Windows.Forms.ComboBox();
            this.btnOKAttribute = new System.Windows.Forms.Button();
            this.btnCloseAttribute = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlScanPartNoFooter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlScanPartNoFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPartAttribute
            // 
            this.lblPartAttribute.AutoSize = true;
            this.lblPartAttribute.Location = new System.Drawing.Point(4, 9);
            this.lblPartAttribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartAttribute.Name = "lblPartAttribute";
            this.lblPartAttribute.Size = new System.Drawing.Size(69, 19);
            this.lblPartAttribute.TabIndex = 0;
            this.lblPartAttribute.Text = "Part No : ";
            // 
            // txtPartAttribute
            // 
            this.txtPartAttribute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPartAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartAttribute.Location = new System.Drawing.Point(108, 9);
            this.txtPartAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartAttribute.Name = "txtPartAttribute";
            this.txtPartAttribute.ReadOnly = true;
            this.txtPartAttribute.Size = new System.Drawing.Size(316, 20);
            this.txtPartAttribute.TabIndex = 4;
            // 
            // lblObsAttribute
            // 
            this.lblObsAttribute.AutoSize = true;
            this.lblObsAttribute.Location = new System.Drawing.Point(4, 59);
            this.lblObsAttribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObsAttribute.Name = "lblObsAttribute";
            this.lblObsAttribute.Size = new System.Drawing.Size(100, 19);
            this.lblObsAttribute.TabIndex = 2;
            this.lblObsAttribute.Text = "Observation : ";
            // 
            // txtObsAttribute
            // 
            this.txtObsAttribute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObsAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsAttribute.Location = new System.Drawing.Point(108, 59);
            this.txtObsAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.txtObsAttribute.Name = "txtObsAttribute";
            this.txtObsAttribute.ReadOnly = true;
            this.txtObsAttribute.Size = new System.Drawing.Size(316, 20);
            this.txtObsAttribute.TabIndex = 5;
            // 
            // lblAtrribute
            // 
            this.lblAtrribute.AutoSize = true;
            this.lblAtrribute.Location = new System.Drawing.Point(4, 113);
            this.lblAtrribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtrribute.Name = "lblAtrribute";
            this.lblAtrribute.Size = new System.Drawing.Size(78, 19);
            this.lblAtrribute.TabIndex = 4;
            this.lblAtrribute.Text = "Attribute : ";
            // 
            // txtAttribute
            // 
            this.txtAttribute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttribute.Location = new System.Drawing.Point(108, 113);
            this.txtAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttribute.Name = "txtAttribute";
            this.txtAttribute.ReadOnly = true;
            this.txtAttribute.Size = new System.Drawing.Size(316, 20);
            this.txtAttribute.TabIndex = 6;
            // 
            // lblDefectsAttribute
            // 
            this.lblDefectsAttribute.AutoSize = true;
            this.lblDefectsAttribute.Location = new System.Drawing.Point(4, 169);
            this.lblDefectsAttribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefectsAttribute.Name = "lblDefectsAttribute";
            this.lblDefectsAttribute.Size = new System.Drawing.Size(71, 19);
            this.lblDefectsAttribute.TabIndex = 6;
            this.lblDefectsAttribute.Text = "Defects : ";
            // 
            // cmbDefectsAttribute
            // 
            this.cmbDefectsAttribute.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cmbDefectsAttribute.DropDownHeight = 100;
            this.cmbDefectsAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectsAttribute.DropDownWidth = 50;
            this.cmbDefectsAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDefectsAttribute.FormattingEnabled = true;
            this.cmbDefectsAttribute.IntegralHeight = false;
            this.cmbDefectsAttribute.Items.AddRange(new object[] {
            "Pass",
            "Fail"});
            this.cmbDefectsAttribute.Location = new System.Drawing.Point(108, 166);
            this.cmbDefectsAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDefectsAttribute.Name = "cmbDefectsAttribute";
            this.cmbDefectsAttribute.Size = new System.Drawing.Size(316, 27);
            this.cmbDefectsAttribute.TabIndex = 1;
            this.cmbDefectsAttribute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDefectsAttribute_KeyDown_1);
            // 
            // btnOKAttribute
            // 
            this.btnOKAttribute.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKAttribute.Location = new System.Drawing.Point(215, 4);
            this.btnOKAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.btnOKAttribute.Name = "btnOKAttribute";
            this.btnOKAttribute.Size = new System.Drawing.Size(100, 34);
            this.btnOKAttribute.TabIndex = 2;
            this.btnOKAttribute.Text = "OK";
            this.btnOKAttribute.UseVisualStyleBackColor = true;
            this.btnOKAttribute.Click += new System.EventHandler(this.btnOKAttribute_Click);
            // 
            // btnCloseAttribute
            // 
            this.btnCloseAttribute.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseAttribute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAttribute.Location = new System.Drawing.Point(323, 4);
            this.btnCloseAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseAttribute.Name = "btnCloseAttribute";
            this.btnCloseAttribute.Size = new System.Drawing.Size(100, 34);
            this.btnCloseAttribute.TabIndex = 3;
            this.btnCloseAttribute.Text = "Close";
            this.btnCloseAttribute.UseVisualStyleBackColor = true;
            this.btnCloseAttribute.Click += new System.EventHandler(this.btnCloseAttribute_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlScanPartNoFooter
            // 
            this.pnlScanPartNoFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlScanPartNoFooter.Controls.Add(this.btnCloseAttribute);
            this.pnlScanPartNoFooter.Controls.Add(this.btnOKAttribute);
            this.pnlScanPartNoFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoFooter.Location = new System.Drawing.Point(1, 200);
            this.pnlScanPartNoFooter.Name = "pnlScanPartNoFooter";
            this.pnlScanPartNoFooter.Size = new System.Drawing.Size(439, 48);
            this.pnlScanPartNoFooter.TabIndex = 22;
            // 
            // frmAttributeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 248);
            this.Controls.Add(this.pnlScanPartNoFooter);
            this.Controls.Add(this.cmbDefectsAttribute);
            this.Controls.Add(this.lblDefectsAttribute);
            this.Controls.Add(this.txtAttribute);
            this.Controls.Add(this.lblAtrribute);
            this.Controls.Add(this.txtObsAttribute);
            this.Controls.Add(this.lblObsAttribute);
            this.Controls.Add(this.txtPartAttribute);
            this.Controls.Add(this.lblPartAttribute);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttributeInput";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attribute Input";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAttributeInput_FormClosing);
            this.Load += new System.EventHandler(this.frmAttributeInput_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmAttributeInput_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlScanPartNoFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPartAttribute;
        private System.Windows.Forms.TextBox txtPartAttribute;
        private System.Windows.Forms.Label lblObsAttribute;
        private System.Windows.Forms.TextBox txtObsAttribute;
        private System.Windows.Forms.Label lblAtrribute;
        private System.Windows.Forms.TextBox txtAttribute;
        private System.Windows.Forms.Label lblDefectsAttribute;
        private System.Windows.Forms.ComboBox cmbDefectsAttribute;
        private System.Windows.Forms.Button btnOKAttribute;
        private System.Windows.Forms.Button btnCloseAttribute;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlScanPartNoFooter;
    }
}