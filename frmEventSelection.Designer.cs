namespace SPC_KDL
{
    partial class frmEventSelection
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMessageEvent = new System.Windows.Forms.Label();
            this.btnRetake = new System.Windows.Forms.Button();
            this.gbEventSelection = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlScanPartNoFooter = new System.Windows.Forms.Panel();
            this.gbEventSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlScanPartNoFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 0;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(8, 30);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(53, 19);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event :";
            // 
            // cmbEvent
            // 
            this.cmbEvent.BackColor = System.Drawing.Color.White;
            this.cmbEvent.DropDownHeight = 150;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.DropDownWidth = 75;
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.IntegralHeight = false;
            this.cmbEvent.Location = new System.Drawing.Point(71, 27);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(442, 27);
            this.cmbEvent.TabIndex = 1;
            this.cmbEvent.SelectionChangeCommitted += new System.EventHandler(this.cmbEvent_SelectionChangeCommitted);
            this.cmbEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEvent_KeyDown);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(8, 66);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(55, 19);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Notes :";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtNotes.Location = new System.Drawing.Point(71, 63);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(442, 81);
            this.txtNotes.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(298, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMessageEvent
            // 
            this.lblMessageEvent.AutoSize = true;
            this.lblMessageEvent.ForeColor = System.Drawing.Color.Red;
            this.lblMessageEvent.Location = new System.Drawing.Point(8, 147);
            this.lblMessageEvent.Name = "lblMessageEvent";
            this.lblMessageEvent.Size = new System.Drawing.Size(0, 19);
            this.lblMessageEvent.TabIndex = 4;
            // 
            // btnRetake
            // 
            this.btnRetake.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRetake.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetake.ForeColor = System.Drawing.Color.Red;
            this.btnRetake.Location = new System.Drawing.Point(412, 8);
            this.btnRetake.Name = "btnRetake";
            this.btnRetake.Size = new System.Drawing.Size(108, 31);
            this.btnRetake.TabIndex = 5;
            this.btnRetake.Text = "Retake";
            this.btnRetake.UseVisualStyleBackColor = true;
            this.btnRetake.Click += new System.EventHandler(this.btnRetake_Click);
            // 
            // gbEventSelection
            // 
            this.gbEventSelection.Controls.Add(this.lblMessageEvent);
            this.gbEventSelection.Controls.Add(this.txtNotes);
            this.gbEventSelection.Controls.Add(this.lblNotes);
            this.gbEventSelection.Controls.Add(this.cmbEvent);
            this.gbEventSelection.Controls.Add(this.lblEvent);
            this.gbEventSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbEventSelection.Location = new System.Drawing.Point(4, 0);
            this.gbEventSelection.Margin = new System.Windows.Forms.Padding(4);
            this.gbEventSelection.Name = "gbEventSelection";
            this.gbEventSelection.Padding = new System.Windows.Forms.Padding(4);
            this.gbEventSelection.Size = new System.Drawing.Size(549, 201);
            this.gbEventSelection.TabIndex = 1;
            this.gbEventSelection.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlScanPartNoFooter
            // 
            this.pnlScanPartNoFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlScanPartNoFooter.Controls.Add(this.btnOK);
            this.pnlScanPartNoFooter.Controls.Add(this.btnRetake);
            this.pnlScanPartNoFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlScanPartNoFooter.Location = new System.Drawing.Point(-3, 208);
            this.pnlScanPartNoFooter.Name = "pnlScanPartNoFooter";
            this.pnlScanPartNoFooter.Size = new System.Drawing.Size(556, 48);
            this.pnlScanPartNoFooter.TabIndex = 22;
            // 
            // frmEventSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 254);
            this.Controls.Add(this.pnlScanPartNoFooter);
            this.Controls.Add(this.gbEventSelection);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEventSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEventSelection_FormClosing);
            this.Load += new System.EventHandler(this.frmEventSelection_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEventSelection_KeyUp);
            this.gbEventSelection.ResumeLayout(false);
            this.gbEventSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlScanPartNoFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMessageEvent;
        private System.Windows.Forms.Button btnRetake;
        private System.Windows.Forms.GroupBox gbEventSelection;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlScanPartNoFooter;
    }
}