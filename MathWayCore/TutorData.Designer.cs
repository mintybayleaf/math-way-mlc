namespace MathLogCenter
{
    partial class TutorData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorData));
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.lsBoxTutors = new System.Windows.Forms.ListView();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTutorList = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlBackGround.Controls.Add(this.lsBoxTutors);
            this.pnlBackGround.Controls.Add(this.lblLName);
            this.pnlBackGround.Controls.Add(this.lblFName);
            this.pnlBackGround.Controls.Add(this.lblID);
            this.pnlBackGround.Controls.Add(this.lblTutorList);
            this.pnlBackGround.Controls.Add(this.btnCancel);
            this.pnlBackGround.Controls.Add(this.btnDone);
            this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGround.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(484, 261);
            this.pnlBackGround.TabIndex = 0;
            // 
            // lsBoxTutors
            // 
            this.lsBoxTutors.Location = new System.Drawing.Point(17, 53);
            this.lsBoxTutors.Name = "lsBoxTutors";
            this.lsBoxTutors.Size = new System.Drawing.Size(455, 136);
            this.lsBoxTutors.TabIndex = 8;
            this.lsBoxTutors.UseCompatibleStateImageBehavior = false;
            this.lsBoxTutors.View = System.Windows.Forms.View.Details;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.ForeColor = System.Drawing.Color.White;
            this.lblLName.Location = new System.Drawing.Point(370, 13);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(36, 19);
            this.lblLName.TabIndex = 4;
            this.lblLName.Text = "###";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.White;
            this.lblFName.Location = new System.Drawing.Point(267, 13);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(36, 19);
            this.lblFName.TabIndex = 3;
            this.lblFName.Text = "###";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(171, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 19);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "###";
            // 
            // lblTutorList
            // 
            this.lblTutorList.AutoSize = true;
            this.lblTutorList.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorList.ForeColor = System.Drawing.Color.White;
            this.lblTutorList.Location = new System.Drawing.Point(13, 13);
            this.lblTutorList.Name = "lblTutorList";
            this.lblTutorList.Size = new System.Drawing.Size(114, 19);
            this.lblTutorList.TabIndex = 1;
            this.lblTutorList.Text = "Tutor List For :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(77, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(278, 211);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(128, 38);
            this.btnDone.TabIndex = 7;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // TutorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.pnlBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TutorData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TutorData";
            this.pnlBackGround.ResumeLayout(false);
            this.pnlBackGround.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackGround;
        private System.Windows.Forms.Label lblTutorList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.ListView lsBoxTutors;
    }
}