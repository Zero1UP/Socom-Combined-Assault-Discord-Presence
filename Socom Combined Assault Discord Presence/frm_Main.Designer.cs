namespace Socom_Combined_Assault_Discord_Presence
{
    partial class frm_Main
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
            this.tmr_GetPCSX2Data = new System.Windows.Forms.Timer(this.components);
            this.tmr_CheckPCSX2 = new System.Windows.Forms.Timer(this.components);
            this.lbl_PCSX2 = new System.Windows.Forms.Label();
            this.CheckBoxS3 = new System.Windows.Forms.CheckBox();
            this.CheckBoxCA = new System.Windows.Forms.CheckBox();
            this.CheckBoxS1 = new System.Windows.Forms.CheckBox();
            this.CheckBoxS2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_RPC = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_GetPCSX2Data
            // 
            this.tmr_GetPCSX2Data.Enabled = true;
            this.tmr_GetPCSX2Data.Interval = 1000;
            this.tmr_GetPCSX2Data.Tick += new System.EventHandler(this.tmr_GetPCSX2Data_Tick);
            // 
            // tmr_CheckPCSX2
            // 
            this.tmr_CheckPCSX2.Enabled = true;
            this.tmr_CheckPCSX2.Tick += new System.EventHandler(this.tmr_CheckPCSX2_Tick);
            // 
            // lbl_PCSX2
            // 
            this.lbl_PCSX2.AutoSize = true;
            this.lbl_PCSX2.Location = new System.Drawing.Point(18, 2);
            this.lbl_PCSX2.Name = "lbl_PCSX2";
            this.lbl_PCSX2.Size = new System.Drawing.Size(35, 13);
            this.lbl_PCSX2.TabIndex = 2;
            this.lbl_PCSX2.Text = "label1";
            // 
            // CheckBoxS3
            // 
            this.CheckBoxS3.AutoSize = true;
            this.CheckBoxS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CheckBoxS3.ForeColor = System.Drawing.Color.White;
            this.CheckBoxS3.Location = new System.Drawing.Point(54, 0);
            this.CheckBoxS3.Name = "CheckBoxS3";
            this.CheckBoxS3.Size = new System.Drawing.Size(44, 21);
            this.CheckBoxS3.TabIndex = 3;
            this.CheckBoxS3.Text = "S3";
            this.CheckBoxS3.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCA
            // 
            this.CheckBoxCA.AutoSize = true;
            this.CheckBoxCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CheckBoxCA.ForeColor = System.Drawing.Color.White;
            this.CheckBoxCA.Location = new System.Drawing.Point(54, 17);
            this.CheckBoxCA.Name = "CheckBoxCA";
            this.CheckBoxCA.Size = new System.Drawing.Size(45, 21);
            this.CheckBoxCA.TabIndex = 4;
            this.CheckBoxCA.Text = "CA";
            this.CheckBoxCA.UseVisualStyleBackColor = true;
            // 
            // CheckBoxS1
            // 
            this.CheckBoxS1.AutoSize = true;
            this.CheckBoxS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CheckBoxS1.ForeColor = System.Drawing.Color.White;
            this.CheckBoxS1.Location = new System.Drawing.Point(3, 0);
            this.CheckBoxS1.Name = "CheckBoxS1";
            this.CheckBoxS1.Size = new System.Drawing.Size(44, 21);
            this.CheckBoxS1.TabIndex = 5;
            this.CheckBoxS1.Text = "S1";
            this.CheckBoxS1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxS2
            // 
            this.CheckBoxS2.AutoSize = true;
            this.CheckBoxS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CheckBoxS2.ForeColor = System.Drawing.Color.White;
            this.CheckBoxS2.Location = new System.Drawing.Point(3, 17);
            this.CheckBoxS2.Name = "CheckBoxS2";
            this.CheckBoxS2.Size = new System.Drawing.Size(44, 21);
            this.CheckBoxS2.TabIndex = 6;
            this.CheckBoxS2.Text = "S2";
            this.CheckBoxS2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CheckBoxS1);
            this.panel1.Controls.Add(this.CheckBoxS2);
            this.panel1.Controls.Add(this.CheckBoxS3);
            this.panel1.Controls.Add(this.CheckBoxCA);
            this.panel1.Location = new System.Drawing.Point(124, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 35);
            this.panel1.TabIndex = 7;
            // 
            // lbl_RPC
            // 
            this.lbl_RPC.AutoSize = true;
            this.lbl_RPC.Location = new System.Drawing.Point(5, 18);
            this.lbl_RPC.Name = "lbl_RPC";
            this.lbl_RPC.Size = new System.Drawing.Size(45, 13);
            this.lbl_RPC.TabIndex = 8;
            this.lbl_RPC.Text = "lbl_RPC";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(221, 35);
            this.Controls.Add(this.lbl_RPC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_PCSX2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(237, 74);
            this.MinimumSize = new System.Drawing.Size(237, 74);
            this.Name = "frm_Main";
            this.Text = "SOCOM CA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_GetPCSX2Data;
        private System.Windows.Forms.Timer tmr_CheckPCSX2;
        private System.Windows.Forms.Label lbl_PCSX2;
        private System.Windows.Forms.CheckBox CheckBoxS3;
        private System.Windows.Forms.CheckBox CheckBoxCA;
        private System.Windows.Forms.CheckBox CheckBoxS1;
        private System.Windows.Forms.CheckBox CheckBoxS2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_RPC;
    }
}

