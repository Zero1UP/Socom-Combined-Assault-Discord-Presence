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
            this.lbl_PCSX2.Location = new System.Drawing.Point(12, 13);
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
            this.CheckBoxS3.Location = new System.Drawing.Point(181, -2);
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
            this.CheckBoxCA.Location = new System.Drawing.Point(181, 15);
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
            this.CheckBoxS1.Location = new System.Drawing.Point(130, -2);
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
            this.CheckBoxS2.Location = new System.Drawing.Point(130, 15);
            this.CheckBoxS2.Name = "CheckBoxS2";
            this.CheckBoxS2.Size = new System.Drawing.Size(44, 21);
            this.CheckBoxS2.TabIndex = 6;
            this.CheckBoxS2.Text = "S2";
            this.CheckBoxS2.UseVisualStyleBackColor = true;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(221, 35);
            this.Controls.Add(this.CheckBoxS2);
            this.Controls.Add(this.CheckBoxS1);
            this.Controls.Add(this.CheckBoxCA);
            this.Controls.Add(this.CheckBoxS3);
            this.Controls.Add(this.lbl_PCSX2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(237, 74);
            this.MinimumSize = new System.Drawing.Size(237, 74);
            this.Name = "frm_Main";
            this.Text = "SOCOM CA";
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
    }
}

