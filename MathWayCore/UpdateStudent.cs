using MathLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class UpdateStudent : UserControl
    {
        private bool validated = false;
        private bool validId = false;
        private bool validFName = false;
        private bool validLName = false;
        private bool validClassNum = false;


        private bool validFNameBottom = false;
        private bool validLNameBottom = false;
        private bool validIdBottom = false;
        private bool validClassNumBottom = false;
        private bool validSemesterBottom = false;
        private bool isRecord = false;
        private StudentRecord student;


        private bool validated_bottom = false;


        public UpdateStudent()
        {
            InitializeComponent();
            this.radioMath.Checked = true;
            this.radioID.Checked = true;
            SetupRadioButtonEvents();
            cmbClassNum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));

            if (cmbClassNum.Items.Count < 1)
            {
                cmbClassNum.Text = string.Empty;
            }
            else
            {
                cmbClassNum.SelectedIndex = 0;
            }
            lockButtons();

        }

        public UpdateStudent(string id, string first, string last, string classType, string classNum)
        {
            InitializeComponent();
            cmbClassNum.DropDownStyle = ComboBoxStyle.DropDownList;
            this.txtID.Text = id.ToUpper();
            this.txtFirst.Text = first.ToUpper();
            this.txtLast.Text = last.ToUpper();
           
            if (classType.Contains("MTH"))
            {
                this.radioMath.Checked = true;
                this.radioOther.Checked = false;
                this.radioStat.Checked = false;

                cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));
            }
            else if (classType.Contains("STAT"))
            {
                this.radioMath.Checked = false;
                this.radioOther.Checked = false;
                this.radioStat.Checked = true;
                cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("STAT"));
            }
            else
            {
                this.radioMath.Checked = false;
                this.radioOther.Checked = true;
                this.radioStat.Checked = false;
                cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("OTH"));
            }

            if (cmbClassNum.Items.Count < 1)
            {
                cmbClassNum.Text = string.Empty;
            }
            else
            {
                cmbClassNum.SelectedIndex = 0;
            }
            this.radioID.Checked = true;
            this.radioName.Checked = false;
            this.chkFilters.Checked = true;
            SetupRadioButtonEvents();

            lockButtons();
        }

        #region Buttons
        private void lockButtons()
        {
            btnSave.Enabled = false;
            btnClearBottom.Enabled = false;
            btnValidateBottom.Enabled = false;
            this.txtChangeFirst.Enabled = false;
            this.txtChangeLast.Enabled = false;
            this.txtChangeID.Enabled = false;
            this.cmbChangeNum.Enabled = false;
            this.cmbChangeSemester.Enabled = false;
            this.radioChangeMath.Enabled = false;
            this.radioChangeStat.Enabled = false;
            this.radioChangeOther.Enabled = false;
        }

        private void unlockButtons()
        {
            btnSave.Enabled = true;
            btnClearBottom.Enabled = true;
            btnValidateBottom.Enabled = true;
            this.txtChangeFirst.Enabled = true;
            this.txtChangeLast.Enabled = true;
            this.txtChangeID.Enabled = true;
            this.cmbChangeNum.Enabled = true;
            this.cmbChangeSemester.Enabled = true;
            this.radioChangeMath.Enabled = true;
            this.radioChangeStat.Enabled = true;
            this.radioChangeOther.Enabled = true;
        }
        private void btnClearBottom_Click(object sender, EventArgs e)
        {
            reset_bottom();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            normal_colors_bottom();
            validator_bottom();
            // Do savey stuff if both top and bottom are good...
            if (validated_bottom && validated && isRecord && !string.IsNullOrEmpty(student.studentID))
            {
                StudentRecord newStudent = new StudentRecord(Convert.ToUInt64(txtChangeID.Text),
                                                             Utility.WordFromBool(radioChangeMath.Checked, radioChangeStat.Checked, radioChangeOther.Checked),
                                                             cmbChangeNum.Text,
                                                             txtChangeFirst.Text,
                                                             txtChangeLast.Text,
                                                             student.numVisits,
                                                             student.totalTime,
                                                             student.timeStamp.ToString("MM/dd/yyyy HH:mm:ss"),
                                                             cmbChangeSemester.Text);



                DConnect.Connection.SaveStudentRecord(newStudent, student.studentID);
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    MessageBox.Show("Update Successful", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_bottom();
            }
            // If not successful
            else
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    MessageBox.Show("Update Not Successful", "Could Not Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                color_errors_bottom();
            }



        }

        private void btnSearchRecords_Click(object sender, EventArgs e)
        {
            isRecord = true;
            normal_colors();
            reset_bottom();

            string searchString = "";
            // Validate of course
            validator();
            // Do some student record stuff here
            if (validated)
            {

                if (radioID.Checked && DConnect.Connection.StudentExists(txtID.Text.Trim()))
                {
                    // Apply the filters...
                    if (chkFilters.Checked )
                    {

                        searchString += "StudentID = " + txtID.Text.Trim();
                        searchString += " AND ClassType = '" + Utility.WordFromBool(radioMath.Checked, radioStat.Checked, radioOther.Checked) + "'";
                        if (!string.IsNullOrEmpty(cmbClassNum.Text))
                        {
                            searchString += " AND ClassNum = '" + cmbClassNum.Text + "'";
                        }

                        bool isSuccess;
                        student = DConnect.Connection.GetRecordBySearchString(searchString, out isSuccess);
                        if (isSuccess)
                        {
                            // Display the student here
                            display_student(student);
                        }
                        else
                        {
                            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                            {
                                MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                       
                    }
                    else
                    {
                        student = DConnect.Connection.GetRecordByID(this.txtID.Text);
                        // Display the student here
                        display_student(student);
                    }
                }
                // Name is checked..search by first and last name
                else if (radioName.Checked && DConnect.Connection.StudentExists(DConnect.Connection.GetRecordByName(txtFirst.Text, txtLast.Text).studentID))
                {
                    // Apply the filters...
                    if (chkFilters.Checked)
                    {
                        searchString += "FirstName = '" + txtFirst.Text.ToUpper().Trim() + "'";
                        searchString += " AND LastName = '" + txtLast.Text.ToUpper().Trim() + "'";
                        // TODO Search and get results for all records by NAME
                        searchString += " AND ClassType = '" + Utility.WordFromBool(radioMath.Checked, radioStat.Checked, radioOther.Checked) + "'";
                        if (!string.IsNullOrEmpty(cmbClassNum.Text))
                        {
                            searchString += " AND ClassNum = '" + cmbClassNum.Text + "'";

                        }
                        bool isSuccess;
                        student = DConnect.Connection.GetRecordBySearchString(searchString, out isSuccess);
                        if (isSuccess)
                        {
                            // Display the student here
                            display_student(student);
                        }
                        else
                        {
                            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                            {
                                MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        student = DConnect.Connection.GetRecordByName(this.txtFirst.Text, this.txtLast.Text);
                        // Display the student here
                        display_student(student);
                    }
                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // If not validated
            else
            {
                color_errors();
                reset_bottom();
            }
        }

        private void btnSearchVisits_Click(object sender, EventArgs e)
        {
            isRecord = false;
            normal_colors();
            reset_bottom();

            string searchString = "";
            // Validate of course
            validator();
            if (validated)
            {

                if (radioID.Checked && DConnect.Connection.StudentExists(txtID.Text.Trim()))
                {
                    // Apply the filters...
                    if (chkFilters.Checked)
                    {

                        searchString += "StudentID = " + txtID.Text.Trim();
                        searchString += " AND ClassType = '" + Utility.WordFromBool(radioMath.Checked, radioStat.Checked, radioOther.Checked) + "'";
                        if (!string.IsNullOrEmpty(cmbClassNum.Text))
                        {
                            searchString += " AND ClassNum = '" + cmbClassNum.Text + "'";
                        }

                        bool isSuccess;
                        student = DConnect.Connection.GetRecordBySearchString(searchString, out isSuccess);
                        if (isSuccess)
                        {
                            // Display the student here
                            EditVisits(student.studentID, student.firstName, student.lastName);
                        }
                        else
                        {
                            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                            {
                                MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }


                    }
                    else
                    {
                        student = DConnect.Connection.GetRecordByID(this.txtID.Text);
                        EditVisits(student.studentID, student.firstName, student.lastName);

                    }
                }
                // Name is checked..search by first and last name
                else if (radioName.Checked && DConnect.Connection.StudentExists(DConnect.Connection.GetRecordByName(txtFirst.Text, txtLast.Text).studentID))
                {
                    // Apply the filters...
                    if (chkFilters.Checked)
                    {
                        searchString += "FirstName = '" + txtFirst.Text.ToUpper().Trim() + "'";
                        searchString += " AND LastName = '" + txtLast.Text.ToUpper().Trim() + "'";
                        // TODO Search and get results for all records by NAME
                        searchString += " AND ClassType = '" + Utility.WordFromBool(radioMath.Checked, radioStat.Checked, radioOther.Checked) + "'";
                        if (!string.IsNullOrEmpty(cmbClassNum.Text))
                        {
                            searchString += " AND ClassNum = '" + cmbClassNum.Text + "'";

                        }
                        bool isSuccess;
                        student = DConnect.Connection.GetRecordBySearchString(searchString, out isSuccess);
                        if (isSuccess)
                        {
                            // Display the student here
                            EditVisits(student.studentID, student.firstName, student.lastName);
                        }
                        else
                        {
                            if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                            {
                                MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    else
                    {
                        student = DConnect.Connection.GetRecordByName(this.txtFirst.Text, this.txtLast.Text);
                        EditVisits(student.studentID, student.firstName, student.lastName);

                    } 
                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    {
                        MessageBox.Show("Student Does Not Exist", "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // If not validated
            else
            {
                color_errors();
            }
        }


     

        private void btnValidate_Click(object sender, EventArgs e)
        {
            normal_colors();
            validator();

            if (validated)
            {
                normal_colors();
            }
            else
            {
                color_errors();
            }
        }

        private void btnValidateBottom_Click(object sender, EventArgs e)
        {
            normal_colors_bottom();
            validator_bottom();

            if (validated_bottom)
            {
                normal_colors_bottom();
            }
            else
            {
                color_errors_bottom();
            }
        }

        /// <summary>
        /// Clears the top section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_top();
            reset_bottom();

        }

        #endregion

        #region Helper Methods

        private void EditVisits(string id, string f, string l)
        {
            if(Convert.ToUInt64(student.numVisits) > 0)
            {
                VisitView view = new VisitView(id, f, l);
                if (view.ShowDialog() == DialogResult.OK)
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                        MessageBox.Show("Updated Successfully", "Visit View Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                        MessageBox.Show("Did not update", "Visit View Over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                    MessageBox.Show("Has No Visits To Edit", "Add a visit and try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void display_student(StudentRecord stu)
        {
            this.txtChangeID.Text = stu.studentID;
            this.txtChangeFirst.Text = stu.firstName;
            this.txtChangeLast.Text = stu.lastName;
            this.cmbChangeSemester.DataSource = DConnect.Connection.GetSemesterChoices();
            cmbChangeSemester.SelectedIndex = cmbChangeSemester.FindStringExact(stu.semester);
            unlockButtons();
            
            if (stu.classType.Contains("MTH"))
            {
                this.radioChangeMath.Checked = true;
                this.radioChangeOther.Checked = false;
                this.radioStat.Checked = false;
                cmbChangeNum.Items.Clear();
                cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));
                cmbChangeNum.SelectedIndex = cmbChangeNum.FindStringExact(stu.classNum);
                
            }
            else if (stu.classType.Contains("STAT"))
            {
                this.radioChangeMath.Checked = false;
                this.radioChangeOther.Checked = false;
                this.radioChangeStat.Checked = true;
                cmbChangeNum.Items.Clear();
                cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("STAT"));
                cmbChangeNum.SelectedIndex = cmbChangeNum.FindStringExact(stu.classNum);

            }
            else
            {
                this.radioChangeMath.Checked = false;
                this.radioChangeOther.Checked = true;
                this.radioChangeStat.Checked = false;
                cmbChangeNum.Items.Clear();
                cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("OTH"));
                cmbChangeNum.SelectedIndex = cmbChangeNum.FindStringExact(stu.classNum);
            }
           
           
        }

        private void SetupRadioButtonEvents()
        {
            radioMath.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbClassNum.Items.Clear();
                if (radioMath.Checked)
                    cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));

                if (cmbClassNum.Items.Count < 1)
                {
                    cmbClassNum.Text = string.Empty;
                }
                else
                {
                    cmbClassNum.SelectedIndex = 0;
                }
            };

            radioStat.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbClassNum.Items.Clear();
                if (radioStat.Checked)
                    cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("STAT"));

                if (cmbClassNum.Items.Count < 1)
                {
                    cmbClassNum.Text = string.Empty;
                }
                else
                {
                    cmbClassNum.SelectedIndex = 0;
                }
            };

            radioOther.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbClassNum.Items.Clear();
                if (radioOther.Checked)
                    cmbClassNum.Items.AddRange(DConnect.Connection.GetClassList("OTH"));

                if (cmbClassNum.Items.Count < 1)
                {
                    cmbClassNum.Text = string.Empty;
                }
                else
                {
                    cmbClassNum.SelectedIndex = 0;
                }
            };

            radioChangeMath.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbChangeNum.Items.Clear();
                
                if (radioChangeMath.Checked)
                    cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));

                if (cmbChangeNum.Items.Count < 1)
                {
                    cmbChangeNum.Text = string.Empty;
                }
                else
                {
                    cmbChangeNum.SelectedIndex = 0;
                }
            };

            radioChangeStat.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbChangeNum.Items.Clear();
                if (radioChangeStat.Checked)
                    cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("STAT"));

                if (cmbChangeNum.Items.Count < 1)
                {
                    cmbChangeNum.Text = string.Empty;
                }
                else
                {
                    cmbChangeNum.SelectedIndex = 0;
                }
            };

            radioChangeOther.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbChangeNum.Items.Clear();
                if (radioChangeOther.Checked)
                    cmbChangeNum.Items.AddRange(DConnect.Connection.GetClassList("OTH"));

                if (cmbChangeNum.Items.Count < 1)
                {
                    cmbChangeNum.Text = string.Empty;
                }
                else
                {
                    cmbChangeNum.SelectedIndex = 0;
                }
            };

        }
        private void reset_top()
        {
            this.txtFirst.Text = string.Empty;
            this.txtID.Text = string.Empty;
            this.txtLast.Text = string.Empty;
            this.cmbClassNum.Text = string.Empty;
            radioID.Checked = true;
            radioMath.Checked = true;
            chkFilters.Checked = false;
            radioName.Checked = false;
            radioStat.Checked = false;
            radioOther.Checked = false;

            normal_colors();
        }


        private void reset_bottom()
        {

            this.txtChangeFirst.Text = string.Empty;
            this.txtChangeID.Text = string.Empty;
            this.txtChangeLast.Text = string.Empty;
            this.cmbChangeSemester.Text = string.Empty;
            this.cmbChangeNum.Text = string.Empty;
            radioChangeMath.Checked = true;
            radioChangeStat.Checked = false;
            radioChangeOther.Checked = false;

            lockButtons();
            normal_colors_bottom();
        }

        private void color_errors_bottom()
        {
            if (!validIdBottom)
            {
                this.txtChangeID.BackColor = Color.LightGreen;
            }

            if (!validFNameBottom)
            {
                this.txtChangeFirst.BackColor = Color.LightGreen;
            }

            if (!validLNameBottom)
            {
                this.txtChangeLast.BackColor = Color.LightGreen;
            }

            if (!validSemesterBottom)
            {
                this.cmbChangeSemester.BackColor = Color.LightGreen;
            }

            if (!validClassNumBottom)
            {
                this.cmbChangeNum.BackColor = Color.LightGreen;
            }
        }

        private void normal_colors_bottom()
        {
            this.txtChangeFirst.BackColor = Color.White;
            this.txtChangeID.BackColor = Color.White;
            this.txtChangeLast.BackColor = Color.White;
            this.cmbChangeSemester.BackColor = Color.White;
            this.cmbChangeNum.BackColor = Color.White;
        }

        private void validator_bottom()
        {
            string first_name = this.txtChangeFirst.Text.Trim();
            string last_name = this.txtChangeLast.Text.Trim();
            string id = this.txtChangeID.Text.Trim();
            string class_num = this.cmbChangeNum.Text.Trim();
            string semester = this.cmbChangeSemester.Text.Trim();

            validIdBottom = MathLib.Validate.number(id) && id.Length > 5;
            validClassNumBottom = MathLib.Validate.number(class_num) && class_num.Length < 5;
            validFNameBottom = MathLib.Validate.loose_string(first_name) && first_name.Length < 40 && !string.IsNullOrEmpty(first_name);
            validLNameBottom = MathLib.Validate.loose_string(last_name) && last_name.Length < 40 && !string.IsNullOrEmpty(last_name);
            validSemesterBottom = !String.IsNullOrEmpty(semester);

            if (validSemesterBottom && validClassNumBottom && validFNameBottom && validLNameBottom && validIdBottom)
            {
                validated_bottom = true;
            }
            else
            {
                validated_bottom = false;
            }

        }

        // Does a bunch of validation work to take the errors out of the hands of the user..
        private void validator()
        {
            string first_name = this.txtFirst.Text.Trim();
            string last_name = this.txtLast.Text.Trim();
            string id = this.txtID.Text.Trim();
            string class_num = this.cmbClassNum.Text.Trim();

            // If only the ID is checked
            if (radioID.Checked)
            {
                // If filters are to be applied
                if (this.chkFilters.Checked)
                {

                    // If there is a class num and class type
                    if ((radioMath.Checked || radioStat.Checked || radioOther.Checked) && !string.IsNullOrEmpty(class_num))
                    {
                        validClassNum = MathLib.Validate.number(class_num) && class_num.Length < 5;
                        validId = MathLib.Validate.number(id) && id.Length > 5;

                        if (validClassNum && validId)
                        {
                            validated = true;
                        }
                        else
                        {
                            validated = false;
                        }
                    }
                    // If only class type filter is applied
                    else
                    {
                        validId = MathLib.Validate.number(id) && id.Length > 5;
                        if (validId)
                        {
                            validated = true;
                        }
                        else
                        {
                            validated = false;
                        }
                    }
                }
                // If the filter is not checked..
                else
                {
                    validId = MathLib.Validate.number(id) && id.Length > 5;
                    if (validId)
                    {
                        validated = true;
                    }
                    else
                    {
                        validated = false;
                    }
                }

            }
            // If the name radio button is checked
            else
            {
                // If the filters are applied
                if (this.chkFilters.Checked)
                {
                    // If there is a classtype and class num
                    if ((radioMath.Checked || radioStat.Checked || radioOther.Checked) && !string.IsNullOrEmpty(class_num))
                    {
                        validClassNum = MathLib.Validate.number(class_num) && class_num.Length < 5;
                        validFName = MathLib.Validate.loose_string(first_name) && first_name.Length < 40 && !string.IsNullOrEmpty(first_name);
                        validLName = MathLib.Validate.loose_string(last_name) && last_name.Length < 40 && !string.IsNullOrEmpty(last_name);
                        if (validFName && validLName && validClassNum)
                        {
                            validated = true;
                        }
                        else
                        {
                            validated = false;
                        }
                    }
                    // If there is not a class num but a classtype
                    else
                    {
                        validFName = MathLib.Validate.loose_string(first_name) && first_name.Length < 40 && !string.IsNullOrEmpty(first_name);
                        validLName = MathLib.Validate.loose_string(last_name) && last_name.Length < 40 && !string.IsNullOrEmpty(last_name);
                        if (validFName && validLName)
                        {
                            validated = true;
                        }
                        else
                        {
                            validated = false;
                        }
                    }
                }
                // If no filters are applied
                else
                {
                    validFName = MathLib.Validate.loose_string(first_name) && first_name.Length < 40 && !string.IsNullOrEmpty(first_name);
                    validLName = MathLib.Validate.loose_string(last_name) && last_name.Length < 40 && !string.IsNullOrEmpty(last_name);
                    if (validFName && validLName)
                    {
                        validated = true;
                    }
                    else
                    {
                        validated = false;
                    }
                }

            }

        }

        private void color_errors()
        {
            if (radioID.Checked)
            {
                if (!validId)
                {
                    this.txtID.BackColor = Color.LightGreen;
                }

                if (chkFilters.Checked)
                {
                    if (!validClassNum)
                    {
                        this.cmbClassNum.BackColor = Color.LightGreen;
                    }
                }
            }
            else
            {

                if (!validFName)
                {
                    this.txtFirst.BackColor = Color.LightGreen;
                }
                if (!validLName)
                {
                    this.txtLast.BackColor = Color.LightGreen;
                }


                if (chkFilters.Checked)
                {
                    if (!validClassNum)
                    {
                        this.cmbClassNum.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        private void normal_colors()
        {
            this.txtFirst.BackColor = Color.White;
            this.txtLast.BackColor = Color.White;
            this.txtID.BackColor = Color.White;
            this.cmbClassNum.BackColor = Color.White;
        }

        #endregion
    }
}
