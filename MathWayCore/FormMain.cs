using MathLib;
using System;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class FormMain : Form
    {
        // Important variables
        private Timer timer = new System.Windows.Forms.Timer();
        private readonly string connection = @"MLCDataStore.sqlite";
        public static readonly int SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
        private string selectedID = "";
        private string selectedFName = "";
        private string selectedLName = "";
        private string selectedClassNum = "";
        private string selectedClassType = "";
        private string currentUser = "";
        private bool isAdmin = false;
        private bool isSuperAdmin = false;
        private Control ctrl;



        public string CurrentUser
        {
            set => currentUser = value;
            get => currentUser;
        }

      

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
            
            this.AutoScaleMode = AutoScaleMode.Inherit;
            // Setup the first panels
            this.MinimumSize = new System.Drawing.Size(SCREEN_WIDTH - 600, SCREEN_HEIGHT - 400);
                 
            int w = this.pnlSplit.Left + 500;
            this.pnlSplit.SplitterDistance = w;
            this.pnlSplit.Panel1MinSize = 500;
            this.pnlSplit.Panel2MinSize = (this.pnlSplit.Width / 2);

            // Connect to the database file and create it if one has not
            // been created in the first place

            DConnect.Connection.ConnectionName = connection;
            DConnect.Connection.Connect();

            if(!DConnect.Connection.HasSetting("ShowFormPopUp"))
            {
                DConnect.Connection.AddSetting("ShowFormPopUp");
            }

            //this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            //this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };

        }



        #endregion

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {

            // Login panel to check for password and get user info
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                isAdmin = login.IsAdmin;
                currentUser = login.User;
                isSuperAdmin = login.IsSuperAdmin;

                if(isAdmin || isSuperAdmin)
                {
                    this.lblUser.Text = "User: " + currentUser;
                }
                else
                {
                    this.lblUser.Text = "User: " + DConnect.Connection.GetUserNameByID(currentUser);
                }
                
            }
            else
            {
                this.Close();
            }

            // Setup Timer
            SetupTimer();


            // Create some events and fill in labels on bottom panel
            this.lblStarted.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            this.btnAbout.Click += (object obj, EventArgs args) => {
                string msg = "\n\n\nMachine Name: " + Environment.MachineName + "\n\n"
                             + "OS Version: " + Environment.OSVersion + "\n\n"
                             + "WindowsUserName: " + Environment.UserName + "\n\n"
                             + "Is64BitMachine: " + Environment.Is64BitOperatingSystem + "\n\n"
                             + "Is64BitProcess: " + Environment.Is64BitProcess + "\n\n"
                             + ".NET Version: " + Environment.Version + "\n\n"
                             + "Processor Count: " + Environment.ProcessorCount + "\n\n"
                             + "MathWay Info: " + Environment.Version + "\n\n"
                             + "Contact For Support: bailey.kocin@gmail.com\n\n"
                             + "Created By Bailey Kocin (bayleaf)\n\n";

                MessageBox.Show(msg, "About -MathWay-", MessageBoxButtons.OK, MessageBoxIcon.Information);

            };

            // Create context menus for the lists
            CreateContextMenus();
            // Set up the lists themselves
            SetUpListsStudents();
            // Fill the lists..
            FillMathList();
            FillOtherList();
            FillStatList();


            // Update the screen
            UpdateScreen("MAIN");
            Status("Ready");

        }

        /// <summary>
        /// If the form size changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            // Splitter distance is the width of the pnlMainScreen
            int w = this.pnlSplit.Left + 500;
            //this.pnlSplit.SplitterDistance = w;
            if (ctrl != null)
            {
                Utility.CenterHorizontal(this.pnlMainScreen, ctrl);
                Utility.CenterVertical(this.pnlMainScreen, ctrl);
            }


        }


        /// <summary>
        /// On the form size change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            int w = this.pnlSplit.Left + 500;
            //this.pnlSplit.SplitterDistance = w;
            if (ctrl != null)
            {
                Utility.CenterHorizontal(this.pnlMainScreen, ctrl);
                Utility.CenterVertical(this.pnlMainScreen, ctrl);
            }
        }

        /// <summary>
        /// When the splitter changers recenter the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (ctrl != null)
            {
                Utility.CenterHorizontal(this.pnlMainScreen, ctrl);
                Utility.CenterVertical(this.pnlMainScreen, ctrl);
            }
        }

        /// <summary>
        /// When a math student is selected fill the bar up top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsMathStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var collection = lsMathStudents.SelectedItems;
            if (collection.Count > 0)
            {

                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "MTH";


                SelectedStudent(id + "-" + first + "-" + last);
            }

        }

        /// <summary>
        /// When a stat student is selected fill the bar uptop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsStatStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var collection = lsStatStudents.SelectedItems;
            if (collection.Count > 0)
            {
                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "STAT";

                SelectedStudent(id + "-" + first + "-" + last);
            }
        }

        /// <summary>
        /// When other student is selected update the top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsOtherStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var collection = lsOtherStudents.SelectedItems;
            if (collection.Count > 0)
            {

                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "OTH";

                SelectedStudent(id + "-" + first + "-" + last);
            }
        }


        private void lsMathStudents_Click(object sender, EventArgs e)
        {
            var collection = lsMathStudents.SelectedItems;
            if (collection.Count == 1)
            {

                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "MTH";


                SelectedStudent(id + "-" + first + "-" + last);
            }
        }

        private void lsStatStudents_Click(object sender, EventArgs e)
        {

            var collection = lsStatStudents.SelectedItems;
            if (collection.Count == 1)
            {

                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "STAT";


                SelectedStudent(id + "-" + first + "-" + last);
            }
        }

        private void lsOtherStudents_Click(object sender, EventArgs e)
        {
            var collection = lsOtherStudents.SelectedItems;
            if (collection.Count == 1)
            {

                string id = collection[0].SubItems[0].Text;
                string first = collection[0].SubItems[1].Text;
                string last = collection[0].SubItems[2].Text;
                string classNum = collection[0].SubItems[3].Text;

                selectedID = id;
                selectedFName = first.ToUpper().Trim();
                selectedLName = last.ToUpper().Trim();
                selectedClassNum = classNum.Trim();
                selectedClassType = "OTH";


                SelectedStudent(id + "-" + first + "-" + last);
            }
        }

        #endregion

        #region Setup

        /// <summary>
        /// Sets up math list box
        /// </summary>
        private void SetUpListsStudents()
        {

            // Set up math list
            lsMathStudents.Columns.Add("Student ID", 150, HorizontalAlignment.Center);
            lsMathStudents.Columns.Add("First Name", 150, HorizontalAlignment.Center);
            lsMathStudents.Columns.Add("Last Name", 150, HorizontalAlignment.Center);
            lsMathStudents.Columns.Add("Class #", 100, HorizontalAlignment.Center);
            lsMathStudents.Columns.Add("Time In", 200, HorizontalAlignment.Center);

            lsMathStudents.Columns[0].Name = "Student ID";
            lsMathStudents.Columns[1].Name = "First Name";
            lsMathStudents.Columns[2].Name = "Last Name";
            lsMathStudents.Columns[3].Name = "Class #";
            lsMathStudents.Columns[4].Name = "Time In";

            lsMathStudents.AllowColumnReorder = false;
            lsMathStudents.FullRowSelect = true;
            lsMathStudents.MultiSelect = false;
            lsMathStudents.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsMathStudents.Sorting = SortOrder.None;
            lsMathStudents.View = View.Details;

            // Set up stats list
            lsStatStudents.Columns.Add("Student ID", 150, HorizontalAlignment.Center);
            lsStatStudents.Columns.Add("First Name", 150, HorizontalAlignment.Center);
            lsStatStudents.Columns.Add("Last Name", 150, HorizontalAlignment.Center);
            lsStatStudents.Columns.Add("Class #", 100, HorizontalAlignment.Center);
            lsStatStudents.Columns.Add("Time In", 200, HorizontalAlignment.Center);

            lsStatStudents.Columns[0].Name = "Student ID";
            lsStatStudents.Columns[1].Name = "First Name";
            lsStatStudents.Columns[2].Name = "Last Name";
            lsStatStudents.Columns[3].Name = "Class #";
            lsStatStudents.Columns[4].Name = "Time In";

            lsStatStudents.AllowColumnReorder = false;
            lsStatStudents.FullRowSelect = true;
            lsStatStudents.MultiSelect = false;
            lsStatStudents.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsStatStudents.Sorting = SortOrder.None;
            lsStatStudents.View = View.Details;

            // Set up other list
            lsOtherStudents.Columns.Add("Student ID", 150, HorizontalAlignment.Center);
            lsOtherStudents.Columns.Add("First Name", 150, HorizontalAlignment.Center);
            lsOtherStudents.Columns.Add("Last Name", 150, HorizontalAlignment.Center);
            lsOtherStudents.Columns.Add("Class #", 100, HorizontalAlignment.Center);
            lsOtherStudents.Columns.Add("Time In", 200, HorizontalAlignment.Center);

            lsOtherStudents.Columns[0].Name = "Student ID";
            lsOtherStudents.Columns[1].Name = "First Name";
            lsOtherStudents.Columns[2].Name = "Last Name";
            lsOtherStudents.Columns[3].Name = "Class #";
            lsOtherStudents.Columns[4].Name = "Time In";

            lsOtherStudents.AllowColumnReorder = false;
            lsOtherStudents.FullRowSelect = true;
            lsOtherStudents.MultiSelect = false;
            lsOtherStudents.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsOtherStudents.Sorting = SortOrder.None;
            lsOtherStudents.View = View.Details;

            lsMathStudents.ColumnWidthChanging += (object sender, ColumnWidthChangingEventArgs e) =>
            {
                SetColumnWidth(lsStatStudents.Columns[e.ColumnIndex], e.NewWidth);
                SetColumnWidth(lsOtherStudents.Columns[e.ColumnIndex], e.NewWidth);

            };

            lsStatStudents.ColumnWidthChanging += (object sender, ColumnWidthChangingEventArgs e) =>
            {
                SetColumnWidth(lsMathStudents.Columns[e.ColumnIndex], e.NewWidth);
                SetColumnWidth(lsOtherStudents.Columns[e.ColumnIndex], e.NewWidth);

            };

            lsOtherStudents.ColumnWidthChanging += (object sender, ColumnWidthChangingEventArgs e) =>
            {
                SetColumnWidth(lsStatStudents.Columns[e.ColumnIndex], e.NewWidth);
                SetColumnWidth(lsMathStudents.Columns[e.ColumnIndex], e.NewWidth);

            };


        }


        private void SetColumnWidth(ColumnHeader col, int w)
        {
            col.Width = w;
        }

        /// Add search function and switch on menu
        /// <summary>
        /// Creates ContextMenus
        /// </summary>
        private void CreateContextMenus()
        {
            MenuItem checkOutMath = new MenuItem("CheckOut", (object obj, EventArgs e) =>
           {
               Status("Checking Out...");
               if(lsMathStudents.SelectedItems.Count > 0)
               {
                   string id = lsMathStudents.SelectedItems[0].SubItems[0].Text;
                   string first = lsMathStudents.SelectedItems[0].SubItems[1].Text;
                   string last = lsMathStudents.SelectedItems[0].SubItems[2].Text;
                   if (DConnect.Connection.IsCheckedIn(id))
                   {

                       TutorData tutors = new TutorData(id, first, last);

                       // If it went over smoothly... then
                       if (tutors.ShowDialog() == DialogResult.OK)
                       {
                           string input = Microsoft.VisualBasic.Interaction.InputBox("What Did The Tutor Do Today?", "Comments", "", FormMain.SCREEN_WIDTH / 2, FormMain.SCREEN_HEIGHT / 2);
                           DConnect.Connection.saveComment(id, input);

                           if (DConnect.Connection.CheckOut(id))
                           {
                               FillMathList();
                               if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                               {
                                   MessageBox.Show("Successfully Checked Out!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               }

                               if (ctrl.GetType().Name == "MainScreen")
                               {
                                   UpdateScreen("MAIN");
                               }
                               SelectedStudent("###-###-###");

                           }
                           else
                           {
                               if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                                   MessageBox.Show("Did Not Check Out!", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }

                       }
                   }

               }


               Status("Done");
           });

            MenuItem searchMath = new MenuItem("Search", (object obj, EventArgs e) =>
            {
                Status("Switching To Search...");
                UpdateScreen("SEARCH_SWITCH");
                Status("Done");
            });

            MenuItem updateMath = new MenuItem("Update", (object obj, EventArgs e) =>
            {
                Status("Switching To Update...");
                UpdateScreen("UPDATE_SWITCH");
                Status("Done");
            });

            MenuItem deleteMath = new MenuItem("Delete", (object obj, EventArgs e) =>
            {
                Status("Switching To Delete...");
                UpdateScreen("DELETE_SWITCH");
                Status("Done");
            });


            MenuItem checkOutStat = new MenuItem("CheckOut", (object obj, EventArgs e) =>
            {
                Status("Checking Out...");
                if(lsStatStudents.SelectedItems.Count > 0)
                {
                    string id = lsStatStudents.SelectedItems[0].SubItems[0].Text;
                    string first = lsStatStudents.SelectedItems[0].SubItems[1].Text;
                    string last = lsStatStudents.SelectedItems[0].SubItems[2].Text;
                    if (DConnect.Connection.IsCheckedIn(id))
                    {

                        TutorData tutors = new TutorData(id, first, last);

                        // If it went over smoothly... then
                        if (tutors.ShowDialog() == DialogResult.OK)
                        {
                            string input = Microsoft.VisualBasic.Interaction.InputBox("What Did The Tutor Do Today?", "Comments", "", FormMain.SCREEN_WIDTH / 2, FormMain.SCREEN_HEIGHT / 2);
                            DConnect.Connection.saveComment(id, input);
                            if (DConnect.Connection.CheckOut(id))
                            {
                                FillStatList();
                                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                                {
                                    MessageBox.Show("Successfully Checked Out!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                SelectedStudent("###-###-###");
                                if (ctrl.GetType().Name == "MainScreen")
                                {
                                    UpdateScreen("MAIN");
                                }


                            }
                            else
                            {
                                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                                    MessageBox.Show("Did Not Check Out!", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
              

              
                Status("Done");
            });

            MenuItem searchStat = new MenuItem("Search", (object obj, EventArgs e) =>
            {
                Status("Switching To Search...");
                UpdateScreen("SEARCH_SWITCH");
                Status("Done");
            });

            MenuItem updateStat = new MenuItem("Update", (object obj, EventArgs e) =>
            {
                Status("Switching To Update...");
                UpdateScreen("UPDATE_SWITCH");
                Status("Done");
            });


            MenuItem deleteStat = new MenuItem("Delete", (object obj, EventArgs e) =>
            {
                Status("Switching To Delete...");
                UpdateScreen("DELETE_SWITCH");
                Status("Done");
            });

            MenuItem checkOutOther = new MenuItem("CheckOut", (object obj, EventArgs e) =>
            {
                Status("Checking Out...");
                if(lsOtherStudents.SelectedItems.Count > 0)
                {
                    string id = lsOtherStudents.SelectedItems[0].SubItems[0].Text;
                    string first = lsOtherStudents.SelectedItems[0].SubItems[1].Text;
                    string last = lsOtherStudents.SelectedItems[0].SubItems[2].Text;
                    if (DConnect.Connection.IsCheckedIn(id))
                    {

                        TutorData tutors = new TutorData(id, first, last);

                        // If it went over smoothly... then
                        if (tutors.ShowDialog() == DialogResult.OK)
                        {
                            string input = Microsoft.VisualBasic.Interaction.InputBox("What Did The Tutor Do Today?", "Comments", "", FormMain.SCREEN_WIDTH / 2, FormMain.SCREEN_HEIGHT / 2);
                            DConnect.Connection.saveComment(id, input);
                            if (DConnect.Connection.CheckOut(id))
                            {
                                FillOtherList();
                                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                                {
                                    MessageBox.Show("Successfully Checked Out!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                if (ctrl.GetType().Name == "MainScreen")
                                {
                                    UpdateScreen("MAIN");
                                }
                                SelectedStudent("###-###-###");
                            }
                            else
                            {
                                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                                    MessageBox.Show("Did Not Check Out!", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
             
               
             
                Status("Done");
            });

            MenuItem searchOther = new MenuItem("Search", (object obj, EventArgs e) =>
            {
                Status("Switching To Search...");
                UpdateScreen("SEARCH_SWITCH");
                Status("Done");
            });

            MenuItem updateOther = new MenuItem("Update", (object obj, EventArgs e) =>
            {
                Status("Switching To Update...");
                UpdateScreen("UPDATE_SWITCH");
                Status("Done");
            });

            MenuItem deleteOther = new MenuItem("Delete", (object obj, EventArgs e) =>
            {
                Status("Switching To Delete...");
                UpdateScreen("DELETE_SWITCH");
                Status("Done");
            });



            lsMathStudents.ContextMenu = new ContextMenu(new MenuItem[] { checkOutMath , searchMath, updateMath, deleteMath});
            lsStatStudents.ContextMenu = new ContextMenu(new MenuItem[] { checkOutStat, searchStat, updateStat, deleteStat });
            lsOtherStudents.ContextMenu = new ContextMenu(new MenuItem[] { checkOutOther, searchOther, updateOther, deleteOther });
        }

        
        /// <summary>
        /// Fill math list view
        /// </summary>
        private void FillMathList()
        {
            CurrentStudentRecord[] r = DConnect.Connection.GetAllMathStudents();
            if (r == null)
            {
                lsMathStudents.Items.Clear();
                return;
            }

            lsMathStudents.Items.Clear();
            foreach (CurrentStudentRecord rec in r)
            {
            
                string[] row = { rec.student.studentID, rec.student.firstName, rec.student.lastName, rec.student.classNum, rec.timeStampIn.ToString("MM/dd/yyyy HH:mm:ss") };
                var item = new ListViewItem(row);
                lsMathStudents.Items.Add(item);
            }
        }


        /// <summary>
        /// Fill other list view
        /// </summary>
        private void FillOtherList()
        {
            CurrentStudentRecord[] r = DConnect.Connection.GetAllOtherStudents();
            if (r == null)
            {
                lsOtherStudents.Items.Clear();
                return;
            }
            lsOtherStudents.Items.Clear();
            foreach (CurrentStudentRecord rec in r)
            {
                string[] row = { rec.student.studentID, rec.student.firstName, rec.student.lastName, rec.student.classNum, rec.timeStampIn.ToString("MM/dd/yyyy HH:mm:ss") };
                var item = new ListViewItem(row);
                lsOtherStudents.Items.Add(item);
            }
        }

        /// <summary>
        /// Fill stat list view
        /// </summary>
        private void FillStatList()
        {
            CurrentStudentRecord[] r = DConnect.Connection.GetAllStatisticsStudents();
            if (r == null)
            {
                lsStatStudents.Items.Clear();
                return;
            }

            lsStatStudents.Items.Clear();
            foreach (CurrentStudentRecord rec in r)
            {
                string[] row = { rec.student.studentID, rec.student.firstName, rec.student.lastName, rec.student.classNum, rec.timeStampIn.ToString("MM/dd/yyyy HH:mm:ss") };
                var item = new ListViewItem(row);
                lsStatStudents.Items.Add(item);
            }
        }



        #endregion

        #region Helper
        /// <summary>
        /// Open the screen based on the event fired via a button or other
        /// </summary>
        /// <param name="fired"></param>
        private void UpdateScreen(string fired = "MAIN")
        {
            if (this.pnlMainScreen.HasChildren)
            {
                this.pnlMainScreen.Controls.Clear();
                // Get Rid of the control by disposing it
                if(ctrl != null)
                {
                    ctrl.Dispose();
                    ctrl = null;
                }
               
            }
            
            switch (fired.ToUpper())
            {
                case "MAIN":
                    Status("Loading....");
                    ctrl = new MainScreen(this.lsMathStudents.Items.Count, this.lsStatStudents.Items.Count, this.lsOtherStudents.Items.Count);
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "ADD":
                    Status("Loading....");
                    ctrl = new AddStudent();
                    SetUpScreen(ctrl);
                    ((AddStudent)(ctrl)).UpdateStudentEventHandler += FillMathList;
                    ((AddStudent)(ctrl)).UpdateStudentEventHandler += FillStatList;
                    ((AddStudent)(ctrl)).UpdateStudentEventHandler += FillOtherList;
                    Status("Ready!");
                    break;
                case "UPDATE_NEW":
                    Status("Loading....");
                    ctrl = new UpdateStudent();
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "UPDATE_SWITCH":
                    Status("Loading....");
                    ctrl = new UpdateStudent(selectedID, selectedFName, selectedLName, selectedClassType, selectedClassNum);
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "SEARCH_NEW":
                    Status("Loading....");
                    ctrl = new SearchStudent();
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillMathList;
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillStatList;
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillOtherList;
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "SEARCH_SWITCH":
                    Status("Loading....");
                    ctrl = new SearchStudent(selectedID, selectedFName, selectedLName, selectedClassType, selectedClassNum);
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillMathList;
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillStatList;
                    ((SearchStudent)(ctrl)).UpdateStudentEventHandler += FillOtherList;
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "DELETE_NEW":
                    Status("Loading....");
                    ctrl = new DeleteStudent();
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "DELETE_SWITCH":
                    Status("Loading....");
                    ctrl = new DeleteStudent(selectedID, selectedFName, selectedLName, selectedClassType, selectedClassNum);
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                case "ADMIN":
                    if(isAdmin)
                    {
                        Status("Loading....");
                        ctrl = new AdminControl();
                        SetUpScreen(ctrl);
                        Status("Ready!");
                    }
                    else if(isSuperAdmin)
                    {
                        Status("Loading....");
                        ctrl = new AdminControl();
                        ((AdminControl)(ctrl)).HideStatTab();
                        SetUpScreen(ctrl);
                        Status("Ready!");
                    }
                    else
                    {
                        Status("Loading....");
                        ctrl = new MainScreen(this.lsMathStudents.Items.Count, this.lsStatStudents.Items.Count, this.lsOtherStudents.Items.Count);
                        SetUpScreen(ctrl);
                        Status("Ready!");
                    }
                   
                    break;
                case "SETTINGS":
                    Status("Loading....");
                    ctrl = new SettingControl();
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                default:
                    Status("Loading....");
                    ctrl = new MainScreen(this.lsMathStudents.Items.Count, this.lsStatStudents.Items.Count, this.lsOtherStudents.Items.Count);
                    SetUpScreen(ctrl);
                    Status("Ready!");
                    break;
                
            }
        }

        // Center a control and fixes the splitter to the new width
        private void SetUpScreen(Control ctrl)
        {
            this.pnlMainScreen.Controls.Add(ctrl);
            int newWidth = ctrl.Width;
            //if(this.pnlSplit.SplitterDistance <= newWidth + 100)
            //{
            //    this.pnlSplit.SplitterDistance = newWidth + 100;
            //}

            Utility.CenterHorizontal(this.pnlMainScreen, ctrl);
            Utility.CenterVertical(this.pnlMainScreen, ctrl);

            ctrl.Focus();
        }

        /// <summary>
        /// Updates the status bar
        /// </summary>
        /// <param name="message"></param>
        private void Status(string message)
        {
            this.lblStatus.Text =  message; 
        }

        /// <summary>
        /// Setups the timer for the clock
        /// </summary>
        private void SetupTimer()
        {
            // Set the time on a label
            timer.Interval = 1000;
            timer.Tick += ((object o, EventArgs args) =>
            {
                this.lblTime.Text = DateTime.Now.ToLongTimeString();
                
            });
            timer.Start();
        }


        // Updates the selected student view
        private void SelectedStudent(string studentText)
        {
            string[] split = studentText.Split('-');
            if(split.Length == 3)
            {
                this.lblDisplayID.Text = "ID: " + split[0].Trim();
                this.lblDisplayFirst.Text = "FirstName: " + split[1].Trim();
                this.lblDisplayLast.Text = "LastName: " + split[2].Trim();
            }

        }
        #endregion

        #region ButtonEvents


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            UpdateScreen("SETTINGS");
            Logger.log.WriteLog("DEBUG", "Settings Button Clicked");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            UpdateScreen("ADMIN");
            Logger.log.WriteLog("DEBUG", "Admin Button Clicked");
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            UpdateScreen("SEARCH_NEW");
            Logger.log.WriteLog("DEBUG", "Search Button Clicked");
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            UpdateScreen("DELETE_NEW");
            Logger.log.WriteLog("DEBUG", "Delete Button Clicked");
        }

        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            UpdateScreen("UPDATE_NEW");
            Logger.log.WriteLog("DEBUG", "Update Button Clicked");
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            UpdateScreen("ADD");
            Logger.log.WriteLog("DEBUG", "Add Student Button Clicked");
        }

        private void btnMainScreen_Click(object sender, EventArgs e)
        {
            UpdateScreen("MAIN");
            Logger.log.WriteLog("DEBUG", "Main Button Clicked");
        }

        // When the form closes make sure the threads being used are closed.
        // This helps ensure data integrity.
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Waits for all the data threads to die...
            if(!isAdmin && !isSuperAdmin)
            {
                DConnect.Connection.UpdateUserTime(this.currentUser, this.lblStarted.Text);
            }
           
            DConnect.Connection.ShutDown();        
        }


        #endregion

 
    }
}
