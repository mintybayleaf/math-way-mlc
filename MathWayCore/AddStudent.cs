using MathLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class AddStudent : UserControl
    {
        private bool validFName = false;
        private bool validLName = false;
        private bool validID = false;
        private bool validNum = false;
        private bool validated = false;
        // Lets choose to update from within visits...
        public delegate void UpdateStudentEvent();
        public event UpdateStudentEvent UpdateStudentEventHandler;

        public AddStudent()
        {
            InitializeComponent();
            cmbNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));

            if (cmbNum.Items.Count < 1)
            {
                cmbNum.Text = string.Empty;
            }
            else
            {
                cmbNum.SelectedIndex = 0;
            }
            SetupRadioButtonEvents();
            this.radioMath.Checked = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            clear();
        }

        private void clear()
        {
            this.txtFirstName.Text = String.Empty;
            this.txtLastName.Text = String.Empty;
            this.txtStudentID.Text = String.Empty;
            this.cmbNum.Text = String.Empty;
            this.radioMath.Checked = true;
            this.radioOther.Checked = false;
            this.radioStat.Checked = false;
           
            normal_colors();
        }

        private void SetupRadioButtonEvents()
        {
            radioMath.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbNum.Items.Clear();
                if (radioMath.Checked)
                    cmbNum.Items.AddRange(DConnect.Connection.GetClassList("MTH"));


                if (cmbNum.Items.Count < 1)
                {
                    cmbNum.Text = string.Empty;
                }
                else
                {
                    cmbNum.SelectedIndex = 0;
                }
            };

            radioStat.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbNum.Items.Clear();
                if (radioStat.Checked)
                    cmbNum.Items.AddRange(DConnect.Connection.GetClassList("STAT"));

                if (cmbNum.Items.Count < 1)
                {
                    cmbNum.Text = string.Empty;
                }
                else
                {
                    cmbNum.SelectedIndex = 0;
                }
            };

            radioOther.CheckedChanged += (object obj, EventArgs e) =>
            {
                cmbNum.Items.Clear();
                if (radioOther.Checked)
                    cmbNum.Items.AddRange(DConnect.Connection.GetClassList("OTH"));

                if (cmbNum.Items.Count < 1)
                {
                    cmbNum.Text = string.Empty;
                }
                else
                {
                    cmbNum.SelectedIndex = 0;
                }
            };

        }
        private void normal_colors()
        {
           
            this.cmbNum.BackColor = Color.White;
            this.txtStudentID.BackColor = Color.White;
            this.txtFirstName.BackColor = Color.White;
            this.txtLastName.BackColor = Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                validator();
                if (validated)
                {
                    if(!DConnect.Connection.StudentExists(this.txtStudentID.Text))
                    {
                        string t = Utility.WordFromBool(radioMath.Checked, radioStat.Checked, radioOther.Checked);
                        DConnect.Connection.AddStudent(txtFirstName.Text, txtLastName.Text, txtStudentID.Text, t, cmbNum.Text);

                        if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                        {
                            MessageBox.Show("Student Added To System", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        DialogResult res = MessageBox.Show("Check In?", "Check Student In as Well??", MessageBoxButtons.YesNo);
                        if(res == DialogResult.Yes)
                        {
                            DConnect.Connection.CheckIn(txtStudentID.Text);
                            if (UpdateStudentEventHandler != null)
                            {
                                UpdateStudentEventHandler();
                            }
                        }
                        clear();
                    }
                    else
                    {
                        if (DConnect.Connection.GetSetting("ShowFormPopUp"))
                        {
                            MessageBox.Show("Student Already Exists", "Could Not Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                }
                else
                {                 
                    color_errors();
                }
            }
            catch (Exception ex)
            {
                Logger.log.WriteLog("FATAL", ex.Message);
            }

        }

        private void color_errors()
        {
            if (!validFName)
            {
                this.txtFirstName.BackColor = Color.LightGreen;
            }

            if (!validLName)
            {
                this.txtLastName.BackColor = Color.LightGreen;
            }

            if (!validID)
            {
                this.txtStudentID.BackColor = Color.LightGreen;
            } 

            if (!validNum)
            {
                this.cmbNum.BackColor = Color.LightGreen;
            }
        }

        private void validator()
        {
            string first_name = this.txtFirstName.Text.Trim();
            string last_name = this.txtLastName.Text.Trim();
            string id = this.txtStudentID.Text.Trim();
            string class_num = this.cmbNum.Text.ToUpper().Trim();

            validID = MathLib.Validate.number(id) && id.Length > 5;
            validFName = MathLib.Validate.loose_string(first_name) && first_name.Length < 40 && !string.IsNullOrEmpty(first_name);
            validLName = MathLib.Validate.loose_string(last_name) && last_name.Length < 40 && !string.IsNullOrEmpty(last_name);
            validNum = MathLib.Validate.number(class_num);

            if (validNum && validID && validFName && validLName)
            {
                validated = true;
            }
            else
            {
                validated = false;
            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
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

       
    }
}
