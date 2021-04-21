namespace SOCOM_CA_Discord_Presence
{
    partial class Form1
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
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_PCSX2Detected = new System.Windows.Forms.Panel();
            this.pcsx2Status = new System.Windows.Forms.Label();
            this.pnl_PCSX2Detected.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessTimer
            // 
            this.ProcessTimer.Enabled = true;
            this.ProcessTimer.Tick += new System.EventHandler(this.ProcessTimer_Tick);
            // 
            // MemoryTimer
            // 
            this.MemoryTimer.Enabled = true;
            this.MemoryTimer.Tick += new System.EventHandler(this.MemoryTimer_Tick);
            // 
            // pnl_PCSX2Detected
            // 
            this.pnl_PCSX2Detected.Controls.Add(this.pcsx2Status);
            this.pnl_PCSX2Detected.Location = new System.Drawing.Point(-1, -1);
            this.pnl_PCSX2Detected.Name = "pnl_PCSX2Detected";
            this.pnl_PCSX2Detected.Size = new System.Drawing.Size(200, 100);
            this.pnl_PCSX2Detected.TabIndex = 0;
            // 
            // pcsx2Status
            // 
            this.pcsx2Status.AutoSize = true;
            this.pcsx2Status.Location = new System.Drawing.Point(12, 9);
            this.pcsx2Status.Name = "pcsx2Status";
            this.pcsx2Status.Size = new System.Drawing.Size(35, 13);
            this.pcsx2Status.TabIndex = 0;
            this.pcsx2Status.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 96);
            this.Controls.Add(this.pnl_PCSX2Detected);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_PCSX2Detected.ResumeLayout(false);
            this.pnl_PCSX2Detected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.Panel pnl_PCSX2Detected;
        private System.Windows.Forms.Label pcsx2Status;
    }
}
