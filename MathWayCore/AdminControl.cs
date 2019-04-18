using MathLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
          

            string[] tutors = DConnect.Connection.GetTutorList();
            Array.Sort(tutors, StringComparer.InvariantCultureIgnoreCase);
            this.cmbTutor.Items.AddRange(tutors);
            
            string[] users = DConnect.Connection.GetUserList();
            Array.Sort(users, StringComparer.InvariantCultureIgnoreCase);
            this.cmbUsersInSystem.Items.AddRange(users);
           
        }

        private bool validated_user = false;
        private bool validated_tutor = false;
        private bool validUserId = false;
        private bool validUserFName = false;
        private bool validUserLName = false;
        private bool validPassword = false;
        private bool validTutorId = false;
        private bool validTutorFName = false;
        private bool validTutorLName = false;
        private string path = "";
        private string dest = "";


        #region Buttons
        private void btnValidateUser_Click(object sender, EventArgs e)
        {
            this.validate_user();
            if (validated_user)
            {
                normal_color_user();
            }
            else
            {
                color_error_user();
            }
        }

        public void HideStatTab()
        {
            this.tabStats.Hide();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            normal_color_user();
            this.validate_user();
            if (validated_user)
            {
                
                if (DConnect.Connection.AddUser(this.txtUserId.Text, this.txtUserFirst.Text, this.txtUserLast.Text, this.txtUserPassword.Text))
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("User Successfully Added", "Added - New User -" + this.txtUserId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.cmbUsersInSystem.Items.Clear();
                    string[] users = DConnect.Connection.GetUserList();
                    Array.Sort(users, StringComparer.InvariantCultureIgnoreCase);
                    this.cmbUsersInSystem.Items.AddRange(users);
                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("User Was Not Added", "Failed To Add User -" + this.txtUserId.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                reset_user();
            }
            else
            {
                color_error_user();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string id = !string.IsNullOrEmpty(this.cmbUsersInSystem.Text) ? this.cmbUsersInSystem.Text.Split('-')[2] : "";
            if (DConnect.Connection.DeleteUserByID(id))
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                {
                    MessageBox.Show("User Successfully Deleted", "Deleted - User -" + this.txtUserId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.cmbUsersInSystem.Items.Clear();
                string[] users = DConnect.Connection.GetUserList();
                Array.Sort(users, StringComparer.InvariantCultureIgnoreCase);
                this.cmbUsersInSystem.Items.AddRange(users);
            }
            else
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                {
                    MessageBox.Show("Failed To Delete", "Did Not Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           

        }


        private void btnValidateTutor_Click(object sender, EventArgs e)
        {
            this.validate_tutor();
            if (validated_tutor)
            {
                normal_color_tutor();
            }
            else
            {
                color_error_tutor();
            }

        }

        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            normal_color_tutor();
            this.validate_tutor();
            if (validated_tutor)
            {
                // TODO add user into dataset on click
                if (DConnect.Connection.AddTutor(this.txtTID.Text, this.txtTFirst.Text, this.txtTLast.Text))
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Tutor Successfully Added", "Added - New Tutor -" + this.txtTID.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.cmbTutor.Items.Clear();
                    string[] tutors = DConnect.Connection.GetTutorList();
                    Array.Sort(tutors, StringComparer.InvariantCultureIgnoreCase);
                    this.cmbTutor.Items.AddRange(tutors);



                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Tutor Was Not Added", "Failed To Add Tutor -" + this.txtTID.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                reset_tutor();
            }
            else
            {
                color_error_tutor();
            }
        }

        private void btnDeleteTutor_Click(object sender, EventArgs e)
        {
            // TODO add user into dataset on click
            string id = !string.IsNullOrEmpty(this.cmbTutor.Text) ? this.cmbTutor.Text.Split('-')[2] : "";
            if (DConnect.Connection.DeleteTutorByID(id))
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                {
                    MessageBox.Show("Tutor Successfully Deleted", "Deleted - Tutor -" + this.txtTID.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.cmbTutor.Items.Clear();
                string[] tutors = DConnect.Connection.GetTutorList();
                Array.Sort(tutors, StringComparer.InvariantCultureIgnoreCase);
                this.cmbTutor.Items.AddRange(tutors);

            }
            else
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                {
                    MessageBox.Show("Tutor Was Not Deleted", "Failed To Delete Tutor -" + this.txtTID.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void btnFileChooser_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    lblLocation.Text = path;
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - btnFileChooser_Click] " + ex.Message);
            }
          
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Let the other stuff just work...
                // Make a function in DConnect to finish threading work....
                if (!string.IsNullOrEmpty(path))
                {
                    // Clone the stuff
                    string p = "MLCDataStore.sqlite";
                    if (!Directory.Exists(path + "\\" + "MLCBackUp"))
                    {
                        Directory.CreateDirectory(path + "\\" + "MLCBackUp");
                    }

                    File.Copy(p, path + "\\MLCBackUp\\MLCData_" + DateTime.Now.GetHashCode().ToString() + ".sqlite");

                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Select A Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        
                }
              
            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - btnBackUp_Click] " + ex.Message);
            }
            lblLocation.Text = "###";
        }


        private void btnChooseBugPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dest = dialog.SelectedPath;
                   lblBugPath.Text = dest;
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - btnChooseBugPath_Click] " + ex.Message);
            }
          

        }

        private void btnZipBugs_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dest))
                {
                    List<FileInfo> files = new List<FileInfo>();

                    foreach (string bug_report in Directory.GetFiles(Environment.CurrentDirectory,"*.data", SearchOption.TopDirectoryOnly))
                    {
                        files.Add(new FileInfo(bug_report));
                    }

                    if (!Directory.Exists(dest + "\\" + "BugReports"))
                    {
                        Directory.CreateDirectory(dest + "\\" + "BugReports");
                    }

                    foreach (FileInfo f in files)
                    {
                        f.CopyTo(dest + "\\" + "BugReports\\" + f.Name);
                        f.Delete();
                    }
                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Select A Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - btnZipBugs_Click] " + ex.Message);
            }

            lblBugPath.Text = "###";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_user();
        }


        private void btnClearTutor_Click(object sender, EventArgs e)
        {
            reset_tutor();
        }


        private void btnAllReport_Click(object sender, EventArgs e)
        {
            ReportViewer viewer = new ReportViewer();
            viewer.StudentReport();
            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
            {
                MessageBox.Show("Student Report Created On Desktop : ", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVisitReport_Click(object sender, EventArgs e)
        {
            ReportViewer viewer = new ReportViewer();
            viewer.AllVisitReport();
            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
            {
                MessageBox.Show("Visit Report Created On Desktop : ", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUserReport_Click(object sender, EventArgs e)
        {
            ReportViewer viewer = new ReportViewer();
            viewer.AllUsersReport();
            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
            {
                MessageBox.Show("User Report Created On Desktop : ", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTutorReport_Click(object sender, EventArgs e)
        {
            ReportViewer viewer = new ReportViewer();
            viewer.AllTutorsReport();
            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
            {
                MessageBox.Show("Tutor Report Created On Desktop : ", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTotalVisits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Students In System : " + DConnect.Connection.GetTotalStudents(), "Total Registered Students", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalVisitByClassType_Click(object sender, EventArgs e)
        {
            string show = "- Total Students In System By Class Type - \n\n" + "MATH : " + DConnect.Connection.GetStudentsPerClassType("MTH") + "\n\n"
                            + "STATISTICS : " + DConnect.Connection.GetStudentsPerClassType("STAT") + "\n\n"
                            + "OTHER : " + DConnect.Connection.GetStudentsPerClassType("OTH") + "\n\n";

            MessageBox.Show(show, "Total Registered Students By Class Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStudentsCurrentSemester_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Students In The System This Semester : " + DConnect.Connection.GetStudentsPerSemester(Lib.GetSemester()), "Total Registered Students - " + Lib.GetSemester(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalStudentRegistered_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Visits In System : " + DConnect.Connection.GetTotalVisits(), "Total Visits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisplayAllSemester_Click(object sender, EventArgs e)
        {
            string show = "- Total Students In System By Class Type - \n\n" + "MATH - " + Lib.GetSemester() + " : " + DConnect.Connection.GetStudentsPerClassTypePerSemester("MTH", Lib.GetSemester()) + "\n\n"
                           + "STATISTICS - " + Lib.GetSemester() + " : " + DConnect.Connection.GetStudentsPerClassTypePerSemester("STAT", Lib.GetSemester()) + "\n\n"
                           + "OTHER - " + Lib.GetSemester() + " : " + DConnect.Connection.GetStudentsPerClassTypePerSemester("OTH", Lib.GetSemester()) + "\n\n";

            MessageBox.Show(show, "Total Registered Students By Class Type By Current Semester", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalSemester_Click(object sender, EventArgs e)
        {
            string show = "Total Tutors : " + DConnect.Connection.GetTotalTutors() + "\n\n" + "Total Users : " + DConnect.Connection.GetTotalUsers() + "\n\n";


            MessageBox.Show(show, "Totat Users and Tutors", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helper Methods

        private void validate_user()
        {
            string first_name = this.txtUserFirst.Text.Trim();
            string last_name = this.txtUserLast.Text.Trim();
            string id = this.txtUserId.Text.Trim();
            string pass = this.txtUserPassword.Text.Trim();

            validUserId = MathLib.Validate.number(id) && id.Length > 5;
            validUserFName = MathLib.Validate.letter_string(first_name) && first_name.Length < 20 && !string.IsNullOrEmpty(first_name);
            validUserLName = MathLib.Validate.letter_string(last_name) && last_name.Length < 20 && !string.IsNullOrEmpty(last_name);
            validPassword = MathLib.Validate.password_string(pass) && !string.IsNullOrEmpty(pass);

            if (validUserId && validUserFName && validUserLName && validPassword)
            {
                validated_user = true;
            }
            else
            {
                validated_user = false;
            }
        }

        private void color_error_user()
        {
            if (!validUserFName)
            {

                this.txtUserFirst.BackColor = Color.LightGreen;
            }

            if (!validUserLName)
            {
                this.txtUserLast.BackColor = Color.LightGreen;
            }

            if (!validUserId)
            {
                this.txtUserId.BackColor = Color.LightGreen;
            }

            if (!validPassword)
            {
                this.txtUserPassword.BackColor = Color.LightGreen;
            }


        }

        private void normal_color_user()
        {
            this.txtUserFirst.BackColor = Color.White;
            this.txtUserLast.BackColor = Color.White;
            this.txtUserId.BackColor = Color.White;
            this.txtUserPassword.BackColor = Color.White;
        }

        private void reset_user()
        {
            this.txtUserFirst.Text = string.Empty;
            this.txtUserLast.Text = string.Empty;
            this.txtUserId.Text = string.Empty;
            this.txtUserPassword.Text = string.Empty;

            normal_color_user();
        }

        private void validate_tutor()
        {
            string first_name = this.txtTFirst.Text.Trim();
            string last_name = this.txtTLast.Text.Trim();
            string id = this.txtTID.Text.Trim();

            validTutorId = MathLib.Validate.number(id) && id.Length > 5;
            validTutorFName = MathLib.Validate.letter_string(first_name) && first_name.Length < 20 && !string.IsNullOrEmpty(first_name);
            validTutorLName = MathLib.Validate.letter_string(last_name) && last_name.Length < 20 && !string.IsNullOrEmpty(last_name);


            if (validTutorId && validTutorFName && validTutorLName)
            {
                validated_tutor = true;
            }
            else
            {
                validated_tutor = false;
            }
        }

        private void color_error_tutor()
        {
            if (!validTutorFName)
            {

                this.txtTFirst.BackColor = Color.LightGreen;
            }

            if (!validTutorLName)
            {
                this.txtTLast.BackColor = Color.LightGreen;
            }

            if (!validTutorId)
            {
                this.txtTID.BackColor = Color.LightGreen;
            }

        }

        private void normal_color_tutor()
        {
            this.txtTFirst.BackColor = Color.White;
            this.txtTLast.BackColor = Color.White;
            this.txtTID.BackColor = Color.White;
        }

        private void reset_tutor()
        {
            this.txtTFirst.Text = string.Empty;
            this.txtTLast.Text = string.Empty;
            this.txtTID.Text = string.Empty;

            normal_color_tutor();
        }








        #endregion

      
    }
}
