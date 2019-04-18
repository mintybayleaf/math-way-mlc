namespace MathLogCenter
{
    partial class VisitView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitView));
            this.lblLName = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTutorList = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.lsBoxVisits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.lsBoxVisits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Maiandra GD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.ForeColor = System.Drawing.Color.White;
            this.lblLName.Location = new System.Drawing.Point(569, 14);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(48, 26);
            this.lblLName.TabIndex = 8;
            this.lblLName.Text = "###";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Maiandra GD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.White;
            this.lblFName.Location = new System.Drawing.Point(433, 14);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(48, 26);
            this.lblFName.TabIndex = 7;
            this.lblFName.Text = "###";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Maiandra GD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(294, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(48, 26);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "###";
            // 
            // lblTutorList
            // 
            this.lblTutorList.AutoSize = true;
            this.lblTutorList.Font = new System.Drawing.Font("Maiandra GD", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorList.ForeColor = System.Drawing.Color.White;
            this.lblTutorList.Location = new System.Drawing.Point(86, 14);
            this.lblTutorList.Name = "lblTutorList";
            this.lblTutorList.Size = new System.Drawing.Size(142, 26);
            this.lblTutorList.TabIndex = 5;
            this.lblTutorList.Text = "Visit List For :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 47);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(417, 320);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(128, 47);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lsBoxVisits
            // 
            this.lsBoxVisits.AllowUserToAddRows = false;
            this.lsBoxVisits.BackgroundColor = System.Drawing.Color.White;
            this.lsBoxVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lsBoxVisits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.lsBoxVisits.Location = new System.Drawing.Point(28, 62);
            this.lsBoxVisits.Name = "lsBoxVisits";
            this.lsBoxVisits.Size = new System.Drawing.Size(702, 230);
            this.lsBoxVisits.TabIndex = 11;
            this.lsBoxVisits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lsBoxVisits_CellDoubleClick);
            // 
            // VisitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(752, 389);
            this.Controls.Add(this.lsBoxVisits);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblTutorList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisitView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisitView";
            ((System.ComponentModel.ISupportInitialize)(this.lsBoxVisits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTutorList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.DataGridView lsBoxVisits;
    }
}