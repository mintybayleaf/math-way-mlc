namespace MathLogCenter
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSplit = new System.Windows.Forms.SplitContainer();
            this.pnlMainScreen = new System.Windows.Forms.Panel();
            this.pnlStudentBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpMathStudents = new System.Windows.Forms.GroupBox();
            this.lsMathStudents = new System.Windows.Forms.ListView();
            this.grpOtherStudents = new System.Windows.Forms.GroupBox();
            this.lsOtherStudents = new System.Windows.Forms.ListView();
            this.grpStatStudents = new System.Windows.Forms.GroupBox();
            this.lsStatStudents = new System.Windows.Forms.ListView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlButtonMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnSearchRecord = new System.Windows.Forms.Button();
            this.btnUpdateRecord = new System.Windows.Forms.Button();
            this.btnMainScreen = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlButtonsTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtonsBottom = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisplayLast = new System.Windows.Forms.Label();
            this.lblDisplayFirst = new System.Windows.Forms.Label();
            this.lblDisplayID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSplit)).BeginInit();
            this.pnlSplit.Panel1.SuspendLayout();
            this.pnlSplit.Panel2.SuspendLayout();
            this.pnlSplit.SuspendLayout();
            this.pnlStudentBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpMathStudents.SuspendLayout();
            this.grpOtherStudents.SuspendLayout();
            this.grpStatStudents.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlButtonMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlButtonsTop.SuspendLayout();
            this.pnlButtonsBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pnlSplit);
            this.panel1.Controls.Add(this.pnlBottom);
            this.panel1.Controls.Add(this.pnlButtons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 761);
            this.panel1.TabIndex = 0;
            // 
            // pnlSplit
            // 
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSplit.Location = new System.Drawing.Point(153, 0);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSplit.Name = "pnlSplit";
            // 
            // pnlSplit.Panel1
            // 
            this.pnlSplit.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlSplit.Panel1.Controls.Add(this.pnlMainScreen);
            // 
            // pnlSplit.Panel2
            // 
            this.pnlSplit.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlSplit.Panel2.Controls.Add(this.pnlStudentBar);
            this.pnlSplit.Size = new System.Drawing.Size(831, 729);
            this.pnlSplit.SplitterDistance = 369;
            this.pnlSplit.SplitterIncrement = 5;
            this.pnlSplit.SplitterWidth = 7;
            this.pnlSplit.TabIndex = 3;
            this.pnlSplit.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.pnlSplit_SplitterMoved);
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlMainScreen.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(369, 729);
            this.pnlMainScreen.TabIndex = 3;
            // 
            // pnlStudentBar
            // 
            this.pnlStudentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlStudentBar.Controls.Add(this.tableLayoutPanel1);
            this.pnlStudentBar.Controls.Add(this.pnlHeader);
            this.pnlStudentBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudentBar.Location = new System.Drawing.Point(0, 0);
            this.pnlStudentBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlStudentBar.Name = "pnlStudentBar";
            this.pnlStudentBar.Size = new System.Drawing.Size(455, 729);
            this.pnlStudentBar.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpMathStudents, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpOtherStudents, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpStatStudents, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 676);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpMathStudents
            // 
            this.grpMathStudents.Controls.Add(this.lsMathStudents);
            this.grpMathStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMathStudents.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMathStudents.ForeColor = System.Drawing.Color.White;
            this.grpMathStudents.Location = new System.Drawing.Point(2, 2);
            this.grpMathStudents.Margin = new System.Windows.Forms.Padding(2);
            this.grpMathStudents.Name = "grpMathStudents";
            this.grpMathStudents.Padding = new System.Windows.Forms.Padding(2);
            this.grpMathStudents.Size = new System.Drawing.Size(451, 221);
            this.grpMathStudents.TabIndex = 1;
            this.grpMathStudents.TabStop = false;
            this.grpMathStudents.Text = "Math Students";
            // 
            // lsMathStudents
            // 
            this.lsMathStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsMathStudents.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsMathStudents.Location = new System.Drawing.Point(2, 18);
            this.lsMathStudents.Margin = new System.Windows.Forms.Padding(2);
            this.lsMathStudents.Name = "lsMathStudents";
            this.lsMathStudents.Size = new System.Drawing.Size(447, 201);
            this.lsMathStudents.TabIndex = 7;
            this.lsMathStudents.UseCompatibleStateImageBehavior = false;
            this.lsMathStudents.SelectedIndexChanged += new System.EventHandler(this.lsMathStudents_SelectedIndexChanged);
            this.lsMathStudents.Click += new System.EventHandler(this.lsMathStudents_Click);
            // 
            // grpOtherStudents
            // 
            this.grpOtherStudents.Controls.Add(this.lsOtherStudents);
            this.grpOtherStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOtherStudents.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOtherStudents.ForeColor = System.Drawing.Color.White;
            this.grpOtherStudents.Location = new System.Drawing.Point(2, 452);
            this.grpOtherStudents.Margin = new System.Windows.Forms.Padding(2);
            this.grpOtherStudents.Name = "grpOtherStudents";
            this.grpOtherStudents.Padding = new System.Windows.Forms.Padding(2);
            this.grpOtherStudents.Size = new System.Drawing.Size(451, 222);
            this.grpOtherStudents.TabIndex = 2;
            this.grpOtherStudents.TabStop = false;
            this.grpOtherStudents.Text = "Other Students";
            // 
            // lsOtherStudents
            // 
            this.lsOtherStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsOtherStudents.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsOtherStudents.Location = new System.Drawing.Point(2, 18);
            this.lsOtherStudents.Margin = new System.Windows.Forms.Padding(2);
            this.lsOtherStudents.Name = "lsOtherStudents";
            this.lsOtherStudents.Size = new System.Drawing.Size(447, 202);
            this.lsOtherStudents.TabIndex = 9;
            this.lsOtherStudents.UseCompatibleStateImageBehavior = false;
            this.lsOtherStudents.SelectedIndexChanged += new System.EventHandler(this.lsOtherStudents_SelectedIndexChanged);
            this.lsOtherStudents.Click += new System.EventHandler(this.lsOtherStudents_Click);
            // 
            // grpStatStudents
            // 
            this.grpStatStudents.Controls.Add(this.lsStatStudents);
            this.grpStatStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatStudents.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatStudents.ForeColor = System.Drawing.Color.White;
            this.grpStatStudents.Location = new System.Drawing.Point(2, 227);
            this.grpStatStudents.Margin = new System.Windows.Forms.Padding(2);
            this.grpStatStudents.Name = "grpStatStudents";
            this.grpStatStudents.Padding = new System.Windows.Forms.Padding(2);
            this.grpStatStudents.Size = new System.Drawing.Size(451, 221);
            this.grpStatStudents.TabIndex = 3;
            this.grpStatStudents.TabStop = false;
            this.grpStatStudents.Text = "Statistics Students";
            // 
            // lsStatStudents
            // 
            this.lsStatStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsStatStudents.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsStatStudents.Location = new System.Drawing.Point(2, 18);
            this.lsStatStudents.Margin = new System.Windows.Forms.Padding(2);
            this.lsStatStudents.Name = "lsStatStudents";
            this.lsStatStudents.Size = new System.Drawing.Size(447, 201);
            this.lsStatStudents.TabIndex = 8;
            this.lsStatStudents.UseCompatibleStateImageBehavior = false;
            this.lsStatStudents.SelectedIndexChanged += new System.EventHandler(this.lsStatStudents_SelectedIndexChanged);
            this.lsStatStudents.Click += new System.EventHandler(this.lsStatStudents_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.panel3);
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(455, 53);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(2, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(316, 27);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "~ Selected Student ~";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.pnlBottom.Controls.Add(this.tableLayoutPanel3);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(153, 729);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(831, 32);
            this.pnlBottom.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.lblStarted, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblUser, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblStatus, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAbout, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(831, 32);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStarted.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarted.ForeColor = System.Drawing.Color.White;
            this.lblStarted.Location = new System.Drawing.Point(416, 0);
            this.lblStarted.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(203, 32);
            this.lblStarted.TabIndex = 2;
            this.lblStarted.Text = "###";
            this.lblStarted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(209, 0);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(203, 32);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "###";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(2, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(203, 32);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "###";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(623, 2);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(206, 28);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "ABOUT";
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.pnlButtonMain);
            this.pnlButtons.Controls.Add(this.pnlButtonsTop);
            this.pnlButtons.Controls.Add(this.pnlButtonsBottom);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(153, 761);
            this.pnlButtons.TabIndex = 0;
            // 
            // pnlButtonMain
            // 
            this.pnlButtonMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(108)))), ((int)(((byte)(163)))));
            this.pnlButtonMain.Controls.Add(this.tableLayoutPanel2);
            this.pnlButtonMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonMain.Location = new System.Drawing.Point(0, 65);
            this.pnlButtonMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtonMain.Name = "pnlButtonMain";
            this.pnlButtonMain.Size = new System.Drawing.Size(153, 631);
            this.pnlButtonMain.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnAdmin, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteRecord, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnAddStudent, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchRecord, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdateRecord, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnMainScreen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSettings, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(153, 631);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.Red;
            this.btnAdmin.Image = global::MathLogCenter.Properties.Resources.appbar4;
            this.btnAdmin.Location = new System.Drawing.Point(2, 542);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(149, 87);
            this.btnAdmin.TabIndex = 6;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteRecord.FlatAppearance.BorderSize = 0;
            this.btnDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRecord.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteRecord.Image = global::MathLogCenter.Properties.Resources.appbar_group_delete;
            this.btnDeleteRecord.Location = new System.Drawing.Point(2, 272);
            this.btnDeleteRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(149, 86);
            this.btnDeleteRecord.TabIndex = 3;
            this.btnDeleteRecord.UseVisualStyleBackColor = false;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnAddStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.ForeColor = System.Drawing.Color.Red;
            this.btnAddStudent.Image = global::MathLogCenter.Properties.Resources.appbar_group1;
            this.btnAddStudent.Location = new System.Drawing.Point(2, 92);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(149, 86);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnSearchRecord
            // 
            this.btnSearchRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnSearchRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchRecord.FlatAppearance.BorderSize = 0;
            this.btnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRecord.ForeColor = System.Drawing.Color.Red;
            this.btnSearchRecord.Image = global::MathLogCenter.Properties.Resources.appbar_page2;
            this.btnSearchRecord.Location = new System.Drawing.Point(2, 362);
            this.btnSearchRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchRecord.Name = "btnSearchRecord";
            this.btnSearchRecord.Size = new System.Drawing.Size(149, 86);
            this.btnSearchRecord.TabIndex = 4;
            this.btnSearchRecord.UseVisualStyleBackColor = false;
            this.btnSearchRecord.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // btnUpdateRecord
            // 
            this.btnUpdateRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnUpdateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateRecord.FlatAppearance.BorderSize = 0;
            this.btnUpdateRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRecord.ForeColor = System.Drawing.Color.Red;
            this.btnUpdateRecord.Image = global::MathLogCenter.Properties.Resources.appbar2;
            this.btnUpdateRecord.Location = new System.Drawing.Point(2, 182);
            this.btnUpdateRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateRecord.Name = "btnUpdateRecord";
            this.btnUpdateRecord.Size = new System.Drawing.Size(149, 86);
            this.btnUpdateRecord.TabIndex = 2;
            this.btnUpdateRecord.UseVisualStyleBackColor = false;
            this.btnUpdateRecord.Click += new System.EventHandler(this.btnUpdateRecord_Click);
            // 
            // btnMainScreen
            // 
            this.btnMainScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainScreen.FlatAppearance.BorderSize = 0;
            this.btnMainScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainScreen.ForeColor = System.Drawing.Color.Red;
            this.btnMainScreen.Image = global::MathLogCenter.Properties.Resources.appbar1;
            this.btnMainScreen.Location = new System.Drawing.Point(2, 2);
            this.btnMainScreen.Margin = new System.Windows.Forms.Padding(2);
            this.btnMainScreen.Name = "btnMainScreen";
            this.btnMainScreen.Size = new System.Drawing.Size(149, 86);
            this.btnMainScreen.TabIndex = 0;
            this.btnMainScreen.UseVisualStyleBackColor = false;
            this.btnMainScreen.Click += new System.EventHandler(this.btnMainScreen_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = global::MathLogCenter.Properties.Resources.appbar3;
            this.btnSettings.Location = new System.Drawing.Point(3, 453);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(147, 84);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlButtonsTop
            // 
            this.pnlButtonsTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.pnlButtonsTop.Controls.Add(this.lblHeader);
            this.pnlButtonsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonsTop.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtonsTop.Name = "pnlButtonsTop";
            this.pnlButtonsTop.Size = new System.Drawing.Size(153, 65);
            this.pnlButtonsTop.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Maiandra GD", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(11, 3);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(128, 57);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "MLC";
            // 
            // pnlButtonsBottom
            // 
            this.pnlButtonsBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.pnlButtonsBottom.Controls.Add(this.lblTitle);
            this.pnlButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonsBottom.Location = new System.Drawing.Point(0, 696);
            this.pnlButtonsBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtonsBottom.Name = "pnlButtonsBottom";
            this.pnlButtonsBottom.Size = new System.Drawing.Size(153, 65);
            this.pnlButtonsBottom.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Maiandra GD", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 58);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Math \r\n     Way";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 26);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.09211F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.45395F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.45395F));
            this.tableLayoutPanel4.Controls.Add(this.lblDisplayLast, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDisplayID, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDisplayFirst, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(455, 26);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblDisplayLast
            // 
            this.lblDisplayLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayLast.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayLast.ForeColor = System.Drawing.Color.White;
            this.lblDisplayLast.Location = new System.Drawing.Point(290, 2);
            this.lblDisplayLast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayLast.Name = "lblDisplayLast";
            this.lblDisplayLast.Size = new System.Drawing.Size(163, 22);
            this.lblDisplayLast.TabIndex = 9;
            this.lblDisplayLast.Text = "LastName: ###";
            this.lblDisplayLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDisplayFirst
            // 
            this.lblDisplayFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayFirst.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayFirst.ForeColor = System.Drawing.Color.White;
            this.lblDisplayFirst.Location = new System.Drawing.Point(125, 2);
            this.lblDisplayFirst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayFirst.Name = "lblDisplayFirst";
            this.lblDisplayFirst.Size = new System.Drawing.Size(161, 22);
            this.lblDisplayFirst.TabIndex = 8;
            this.lblDisplayFirst.Text = "FirstName: ###";
            this.lblDisplayFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDisplayID
            // 
            this.lblDisplayID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayID.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayID.ForeColor = System.Drawing.Color.White;
            this.lblDisplayID.Location = new System.Drawing.Point(2, 2);
            this.lblDisplayID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplayID.Name = "lblDisplayID";
            this.lblDisplayID.Size = new System.Drawing.Size(119, 22);
            this.lblDisplayID.TabIndex = 7;
            this.lblDisplayID.Text = "ID: ###";
            this.lblDisplayID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 27);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.32967F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.67033F));
            this.tableLayoutPanel5.Controls.Add(this.lblInfo, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTime, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(455, 27);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(453, 0);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 27);
            this.lblTime.TabIndex = 2;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(100, 600);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLC MathWays";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.panel1.ResumeLayout(false);
            this.pnlSplit.Panel1.ResumeLayout(false);
            this.pnlSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSplit)).EndInit();
            this.pnlSplit.ResumeLayout(false);
            this.pnlStudentBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpMathStudents.ResumeLayout(false);
            this.grpOtherStudents.ResumeLayout(false);
            this.grpStatStudents.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtonMain.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlButtonsTop.ResumeLayout(false);
            this.pnlButtonsTop.PerformLayout();
            this.pnlButtonsBottom.ResumeLayout(false);
            this.pnlButtonsBottom.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlMainScreen;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlButtonsTop;
        private System.Windows.Forms.Panel pnlButtonsBottom;
        private System.Windows.Forms.ListView lsMathStudents;
        private System.Windows.Forms.ListView lsOtherStudents;
        private System.Windows.Forms.ListView lsStatStudents;
        private System.Windows.Forms.Panel pnlButtonMain;
        private System.Windows.Forms.Button btnMainScreen;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnUpdateRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnSearchRecord;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.GroupBox grpStatStudents;
        private System.Windows.Forms.GroupBox grpOtherStudents;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpMathStudents;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.SplitContainer pnlSplit;
        private System.Windows.Forms.Panel pnlStudentBar;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblDisplayLast;
        private System.Windows.Forms.Label lblDisplayID;
        private System.Windows.Forms.Label lblDisplayFirst;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblTime;
    }
}

