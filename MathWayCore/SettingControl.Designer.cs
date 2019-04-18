namespace MathLogCenter
{
    partial class SettingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpUsers = new System.Windows.Forms.GroupBox();
            this.headMain = new System.Windows.Forms.TabControl();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grpBug = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.txtBugBox = new System.Windows.Forms.TextBox();
            this.grpAppearance = new System.Windows.Forms.GroupBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.radioSmall = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.radioBig = new System.Windows.Forms.RadioButton();
            this.radioHuge = new System.Windows.Forms.RadioButton();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.grpFlag = new System.Windows.Forms.GroupBox();
            this.chkPopUp = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.grpUsers.SuspendLayout();
            this.headMain.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.panel7.SuspendLayout();
            this.grpBug.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.grpFlag.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.grpUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 600);
            this.panel1.TabIndex = 1;
            // 
            // grpUsers
            // 
            this.grpUsers.Controls.Add(this.headMain);
            this.grpUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUsers.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUsers.ForeColor = System.Drawing.Color.White;
            this.grpUsers.Location = new System.Drawing.Point(0, 0);
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Size = new System.Drawing.Size(500, 600);
            this.grpUsers.TabIndex = 0;
            this.grpUsers.TabStop = false;
            this.grpUsers.Text = "User Settings";
            // 
            // headMain
            // 
            this.headMain.Controls.Add(this.tabSettings);
            this.headMain.Controls.Add(this.tabOther);
            this.headMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headMain.Location = new System.Drawing.Point(3, 23);
            this.headMain.Name = "headMain";
            this.headMain.SelectedIndex = 0;
            this.headMain.Size = new System.Drawing.Size(494, 574);
            this.headMain.TabIndex = 0;
            // 
            // tabOther
            // 
            this.tabOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.tabOther.Controls.Add(this.panel7);
            this.tabOther.ForeColor = System.Drawing.Color.White;
            this.tabOther.Location = new System.Drawing.Point(4, 28);
            this.tabOther.Name = "tabOther";
            this.tabOther.Size = new System.Drawing.Size(486, 542);
            this.tabOther.TabIndex = 4;
            this.tabOther.Text = "Other";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel7.Controls.Add(this.grpBug);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(486, 542);
            this.panel7.TabIndex = 1;
            // 
            // grpBug
            // 
            this.grpBug.Controls.Add(this.btnReport);
            this.grpBug.Controls.Add(this.txtBugBox);
            this.grpBug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBug.ForeColor = System.Drawing.Color.White;
            this.grpBug.Location = new System.Drawing.Point(0, 0);
            this.grpBug.Name = "grpBug";
            this.grpBug.Size = new System.Drawing.Size(486, 542);
            this.grpBug.TabIndex = 6;
            this.grpBug.TabStop = false;
            this.grpBug.Text = "Report A Bug";
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Location = new System.Drawing.Point(3, 509);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(480, 30);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Report Bug";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // txtBugBox
            // 
            this.txtBugBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBugBox.Location = new System.Drawing.Point(3, 23);
            this.txtBugBox.Multiline = true;
            this.txtBugBox.Name = "txtBugBox";
            this.txtBugBox.Size = new System.Drawing.Size(480, 516);
            this.txtBugBox.TabIndex = 0;
            // 
            // grpAppearance
            // 
            this.grpAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAppearance.ForeColor = System.Drawing.Color.White;
            this.grpAppearance.Location = new System.Drawing.Point(0, 0);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Size = new System.Drawing.Size(460, 181);
            this.grpAppearance.TabIndex = 2;
            this.grpAppearance.TabStop = false;
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(15, 37);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(77, 19);
            this.lblFontSize.TabIndex = 0;
            // 
            // radioSmall
            // 
            this.radioSmall.AutoSize = true;
            this.radioSmall.Location = new System.Drawing.Point(98, 35);
            this.radioSmall.Name = "radioSmall";
            this.radioSmall.Size = new System.Drawing.Size(64, 23);
            this.radioSmall.TabIndex = 2;
            this.radioSmall.TabStop = true;
            this.radioSmall.Text = "Small";
            this.radioSmall.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            this.radioMedium.AutoSize = true;
            this.radioMedium.Location = new System.Drawing.Point(179, 35);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(86, 23);
            this.radioMedium.TabIndex = 3;
            this.radioMedium.TabStop = true;
            this.radioMedium.Text = "Medium";
            this.radioMedium.UseVisualStyleBackColor = true;
            // 
            // radioBig
            // 
            this.radioBig.AutoSize = true;
            this.radioBig.Location = new System.Drawing.Point(287, 35);
            this.radioBig.Name = "radioBig";
            this.radioBig.Size = new System.Drawing.Size(48, 23);
            this.radioBig.TabIndex = 4;
            this.radioBig.TabStop = true;
            this.radioBig.Text = "Big";
            this.radioBig.UseVisualStyleBackColor = true;
            // 
            // radioHuge
            // 
            this.radioHuge.AutoSize = true;
            this.radioHuge.Location = new System.Drawing.Point(360, 35);
            this.radioHuge.Name = "radioHuge";
            this.radioHuge.Size = new System.Drawing.Size(65, 23);
            this.radioHuge.TabIndex = 5;
            this.radioHuge.TabStop = true;
            this.radioHuge.Text = "Huge";
            this.radioHuge.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.tabSettings.Controls.Add(this.grpFlag);
            this.tabSettings.Location = new System.Drawing.Point(4, 28);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(486, 542);
            this.tabSettings.TabIndex = 5;
            this.tabSettings.Text = "Main";
            // 
            // grpFlag
            // 
            this.grpFlag.Controls.Add(this.chkPopUp);
            this.grpFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFlag.ForeColor = System.Drawing.Color.White;
            this.grpFlag.Location = new System.Drawing.Point(3, 3);
            this.grpFlag.Name = "grpFlag";
            this.grpFlag.Size = new System.Drawing.Size(480, 536);
            this.grpFlag.TabIndex = 7;
            this.grpFlag.TabStop = false;
            this.grpFlag.Text = "Settings";
            // 
            // chkPopUp
            // 
            this.chkPopUp.AutoSize = true;
            this.chkPopUp.Location = new System.Drawing.Point(28, 39);
            this.chkPopUp.Name = "chkPopUp";
            this.chkPopUp.Size = new System.Drawing.Size(287, 23);
            this.chkPopUp.TabIndex = 0;
            this.chkPopUp.Text = "Show Success/Error PopUps On Click";
            this.chkPopUp.UseVisualStyleBackColor = true;
            this.chkPopUp.CheckedChanged += new System.EventHandler(this.chkPopUp_CheckedChanged);
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SettingControl";
            this.Size = new System.Drawing.Size(500, 600);
            this.panel1.ResumeLayout(false);
            this.grpUsers.ResumeLayout(false);
            this.headMain.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.grpBug.ResumeLayout(false);
            this.grpBug.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.grpFlag.ResumeLayout(false);
            this.grpFlag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpUsers;
        private System.Windows.Forms.TabControl headMain;
        private System.Windows.Forms.TabPage tabOther;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox grpBug;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox txtBugBox;
        private System.Windows.Forms.GroupBox grpAppearance;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.RadioButton radioSmall;
        private System.Windows.Forms.RadioButton radioMedium;
        private System.Windows.Forms.RadioButton radioBig;
        private System.Windows.Forms.RadioButton radioHuge;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox grpFlag;
        private System.Windows.Forms.CheckBox chkPopUp;
    }
}
