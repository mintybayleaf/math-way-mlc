namespace MathLogCenter
{
    partial class EditTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTime));
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.txtNewTime = new System.Windows.Forms.TextBox();
            this.txtOldTime = new System.Windows.Forms.TextBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblNewTime = new System.Windows.Forms.Label();
            this.lblOldTime = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblEditTimeFor = new System.Windows.Forms.Label();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlBackGround.Controls.Add(this.datePicker);
            this.pnlBackGround.Controls.Add(this.timePicker);
            this.pnlBackGround.Controls.Add(this.txtNewTime);
            this.pnlBackGround.Controls.Add(this.txtOldTime);
            this.pnlBackGround.Controls.Add(this.lblSelect);
            this.pnlBackGround.Controls.Add(this.btnCancel);
            this.pnlBackGround.Controls.Add(this.btnDone);
            this.pnlBackGround.Controls.Add(this.lblNewTime);
            this.pnlBackGround.Controls.Add(this.lblOldTime);
            this.pnlBackGround.Controls.Add(this.lblLName);
            this.pnlBackGround.Controls.Add(this.lblFName);
            this.pnlBackGround.Controls.Add(this.lblID);
            this.pnlBackGround.Controls.Add(this.lblEditTimeFor);
            this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGround.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(498, 323);
            this.pnlBackGround.TabIndex = 1;
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(280, 135);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(149, 27);
            this.datePicker.TabIndex = 15;
            this.datePicker.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // timePicker
            // 
            this.timePicker.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(118, 135);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(128, 27);
            this.timePicker.TabIndex = 14;
            this.timePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtNewTime
            // 
            this.txtNewTime.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTime.Location = new System.Drawing.Point(118, 189);
            this.txtNewTime.Name = "txtNewTime";
            this.txtNewTime.ReadOnly = true;
            this.txtNewTime.Size = new System.Drawing.Size(311, 27);
            this.txtNewTime.TabIndex = 13;
            // 
            // txtOldTime
            // 
            this.txtOldTime.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldTime.Location = new System.Drawing.Point(118, 77);
            this.txtOldTime.Name = "txtOldTime";
            this.txtOldTime.ReadOnly = true;
            this.txtOldTime.Size = new System.Drawing.Size(311, 27);
            this.txtOldTime.TabIndex = 12;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.Color.White;
            this.lblSelect.Location = new System.Drawing.Point(12, 141);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(81, 19);
            this.lblSelect.TabIndex = 6;
            this.lblSelect.Text = "Edit Time:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(79, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(280, 258);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(128, 38);
            this.btnDone.TabIndex = 11;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblNewTime
            // 
            this.lblNewTime.AutoSize = true;
            this.lblNewTime.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewTime.ForeColor = System.Drawing.Color.White;
            this.lblNewTime.Location = new System.Drawing.Point(12, 197);
            this.lblNewTime.Name = "lblNewTime";
            this.lblNewTime.Size = new System.Drawing.Size(94, 19);
            this.lblNewTime.TabIndex = 8;
            this.lblNewTime.Text = "New Time :";
            // 
            // lblOldTime
            // 
            this.lblOldTime.AutoSize = true;
            this.lblOldTime.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldTime.ForeColor = System.Drawing.Color.White;
            this.lblOldTime.Location = new System.Drawing.Point(13, 79);
            this.lblOldTime.Name = "lblOldTime";
            this.lblOldTime.Size = new System.Drawing.Size(86, 19);
            this.lblOldTime.TabIndex = 4;
            this.lblOldTime.Text = "Old Time :";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.ForeColor = System.Drawing.Color.White;
            this.lblLName.Location = new System.Drawing.Point(364, 13);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(36, 19);
            this.lblLName.TabIndex = 3;
            this.lblLName.Text = "###";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.White;
            this.lblFName.Location = new System.Drawing.Point(261, 13);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(36, 19);
            this.lblFName.TabIndex = 2;
            this.lblFName.Text = "###";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(165, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 19);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "###";
            // 
            // lblEditTimeFor
            // 
            this.lblEditTimeFor.AutoSize = true;
            this.lblEditTimeFor.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditTimeFor.ForeColor = System.Drawing.Color.White;
            this.lblEditTimeFor.Location = new System.Drawing.Point(13, 13);
            this.lblEditTimeFor.Name = "lblEditTimeFor";
            this.lblEditTimeFor.Size = new System.Drawing.Size(115, 19);
            this.lblEditTimeFor.TabIndex = 0;
            this.lblEditTimeFor.Text = "Edit Time For :";
            // 
            // EditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 323);
            this.Controls.Add(this.pnlBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditTime";
            this.pnlBackGround.ResumeLayout(false);
            this.pnlBackGround.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel pnlBackGround;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblEditTimeFor;
        private System.Windows.Forms.Label lblNewTime;
        private System.Windows.Forms.Label lblOldTime;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox txtNewTime;
        private System.Windows.Forms.TextBox txtOldTime;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker timePicker;
    }
}