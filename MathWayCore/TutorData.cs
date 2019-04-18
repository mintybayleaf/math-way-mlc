using MathLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class TutorData : Form
    {
        private string id = "";
        private string first = "";
        private string last = "";
        private string tutors = "";
        private string visitNum = "";
        private List<ListViewItem> used = new List<ListViewItem>();

        public string ID
        {
            set => id = value;
            get => id;
        }

        public string First
        {
            set => first = value;
            get => first;
        }

        public string Last
        {
            set => last = value;
            get => last;
        }

        // Will be the validated string
        public string Tutors
        {
            get => tutors;
            set => tutors = value;
        }

        public TutorData()
        {
            InitializeComponent();
        }


        public TutorData(string id, string first, string last)
        {
            InitializeComponent();
            this.lblID.Text = id.ToUpper();
            this.lblFName.Text = first.ToUpper();
            this.lblLName.Text = last.ToUpper();

            this.id = id.ToUpper();
            this.first = first.ToUpper();
            this.last = last.ToUpper();

            SetupList();
            // Get all the tutors
            FillList();

        }

        public TutorData(string id, string first, string last, string visit_num)
        {
            InitializeComponent();
            this.lblID.Text = id.ToUpper();
            this.lblFName.Text = first.ToUpper();
            this.lblLName.Text = last.ToUpper();

            this.id = id.ToUpper();
            this.first = first.ToUpper();
            this.last = last.ToUpper();
            this.visitNum = visit_num;

            SetupList();
            // Get all the tutors
            FillListVisit();

        }

        private void SetupList()
        {
            lsBoxTutors.Columns.Add("FirstName", 100, HorizontalAlignment.Center);
            lsBoxTutors.Columns.Add("LastName", 100, HorizontalAlignment.Center);
            lsBoxTutors.Columns.Add("StudentID", 75, HorizontalAlignment.Center);
            lsBoxTutors.Columns[0].Name = "FirstName";
            lsBoxTutors.Columns[1].Name = "LastName";
            lsBoxTutors.Columns[2].Name = "StudentID";
            lsBoxTutors.CheckBoxes = true;
            lsBoxTutors.MultiSelect = true;
            lsBoxTutors.HeaderStyle = ColumnHeaderStyle.None;
            lsBoxTutors.View = View.Details;
            lsBoxTutors.AllowColumnReorder = false;

        }

        // Fill lists based on visit selected with the id....
        private void FillListVisit()
        {
            string[] tutors = DConnect.Connection.GetTutorList();
            Array.Sort(tutors, StringComparer.InvariantCultureIgnoreCase);

            foreach (string tutor in tutors)
            {
                string fname = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[0] : "";
                string lname = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[1] : "";
                string id = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[2] : "";
                var item = lsBoxTutors.Items.Add(new ListViewItem(new String[] { fname, lname, id }));
                if (DConnect.Connection.StudentHasTutor(this.id, fname, lname, visitNum))
                {
                    used.Add(item);
                    item.Checked = true;                  
                }
            }
        }

        // Fill with check out student info...
        private void FillList()
        {
            string[] tutors = DConnect.Connection.GetTutorList();
          
            foreach (string tutor in tutors)
            {
                string fname = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[0] : "";
                string lname = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[1] : "";
                string id = !string.IsNullOrEmpty(tutor) ? tutor.Split('-')[2] : "";
                var item = lsBoxTutors.Items.Add(new ListViewItem(new String[] { fname, lname, id }));

            }

        }

        private void UpdateTutors()
        {
            
            foreach (ListViewItem i in lsBoxTutors.CheckedItems)
            {
              
                string fname = i.SubItems[0].Text;
                string lname = i.SubItems[1].Text;
                string id = i.SubItems[2].Text;
                CurrentStudentRecord stu = DConnect.Connection.GetCheckedInStudentByID(this.id);
                if (!DConnect.Connection.StudentHasTutor(this.id, fname, lname))
                {
                    string t = fname + " " + lname;
                    DConnect.Connection.UpdateStudentTutorList(this.id, t, "1");

                    // It has no value...

                    if (stu.timeStampOut.Equals(DateTime.MaxValue))
                    {
                        UInt64 later = Lib.FixTime(DateTime.Now);
                        UInt64 before = Lib.FixTime(stu.timeStampIn);
                        DConnect.Connection.UpdateTutorTimeByAmount(id, later - before);
                    }
                    else
                    {
                        UInt64 later = Lib.FixTime(stu.timeStampOut);
                        UInt64 before = Lib.FixTime(stu.timeStampIn);
                        DConnect.Connection.UpdateTutorTimeByAmount(id, later - before);
                    }
                }

            }

            // These are the tutors who were removed so remove the time from them
            // I dont want them to get extra credit...
           
        }

        private void UpdateVisitsTutors()
        {
            foreach (ListViewItem i in lsBoxTutors.CheckedItems)
            {
                if (used.Contains(i))
                {
                    used.Remove(i);
                }

                string fname = i.SubItems[0].Text;
                string lname = i.SubItems[1].Text;
                string id = i.SubItems[2].Text;
                CurrentStudentRecord stu = DConnect.Connection.GetCheckedInStudentByID(this.id, visitNum);

                // The tutor has not been here so we need to add it.....
                if (!DConnect.Connection.StudentHasTutor(this.id, fname, lname, visitNum))
                {
                    string t = fname + " " + lname;
                    DConnect.Connection.UpdateStudentTutorList(this.id, t, "0", visitNum);

                    // It has no value...

                    if (stu.timeStampOut.Equals(DateTime.MaxValue))
                    {
                        UInt64 later = Lib.FixTime(DateTime.Now);
                        UInt64 before = Lib.FixTime(stu.timeStampIn);
                        DConnect.Connection.UpdateTutorTimeByAmount(id, later - before);
                    }
                    else
                    {
                        UInt64 later = Lib.FixTime(stu.timeStampOut);
                        UInt64 before = Lib.FixTime(stu.timeStampIn);
                        DConnect.Connection.UpdateTutorTimeByAmount(id, later - before);
                    }
                }

            }

            

            // Tutors in the previous that were not in this one..
            // Remove times to keep things fair...
            foreach (ListViewItem i in used)
            {
                string fname = i.SubItems[0].Text;
                string lname = i.SubItems[1].Text;
                string id = i.SubItems[2].Text;
                CurrentStudentRecord stu = DConnect.Connection.GetCheckedInStudentByID(this.id, visitNum);

                DConnect.Connection.RemoveTutorFromStudentByID(fname, lname, this.id, visitNum);

                if (stu.timeStampOut.Equals(DateTime.MaxValue))
                {
                    UInt64 later = Lib.FixTime(DateTime.Now);
                    UInt64 before = Lib.FixTime(stu.timeStampIn);
                    DConnect.Connection.UpdateTutorTimeByAmount(id, later - before, true);
                }
                else
                {
                    UInt64 later = Lib.FixTime(stu.timeStampOut);
                    UInt64 before = Lib.FixTime(stu.timeStampIn);
                    DConnect.Connection.UpdateTutorTimeByAmount(id, later - before, true);
                }
            }

            CurrentStudentRecord updated = DConnect.Connection.GetCheckedInStudentByID(this.id, visitNum);
           
          
                this.tutors = string.Join(",", updated.tutors);
            
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Just close and make no changes!
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // Update the linked tutors in the current student visit record
            if (String.IsNullOrEmpty(visitNum))
            {
                UpdateTutors();
            }
            else
            {
                UpdateVisitsTutors();
            }
          
            this.DialogResult = DialogResult.OK;
        }

    }
}
