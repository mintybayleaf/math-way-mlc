using System;
using System.Collections.Generic;

namespace MathLib
{
    // The student inside the MLC current information
    public struct CurrentStudentRecord
    {
        public StudentRecord student;
        public string studentID;
        public String[] tutors;
        public DateTime timeStampIn;
        public DateTime timeStampOut;
        public string semester;
        public bool status;
        string classNum;
        string classType;

        public CurrentStudentRecord(StudentRecord record, UInt64 id, string tutor, string timeIn, string timeOut, string semester, string status, string classType, string classNum)
        {
            this.studentID = id.ToString();
            this.student = record;
            this.tutors = string.IsNullOrEmpty(tutor) ? new string[] { "" } : tutor.Split(',');
            List<string> ls = new List<string>();
            foreach (string s in tutors)
            {
                if (!s.Equals("") && !string.IsNullOrEmpty(s))
                {
                    ls.Add(s);
                }
            }
            this.tutors = ls.ToArray();
            this.timeStampIn = Validate.strict_date(timeIn) ? DateTime.ParseExact(timeIn, "MM/dd/yyyy HH:mm:ss", null) : DateTime.MaxValue;
            this.timeStampOut = Validate.strict_date(timeOut) ? DateTime.ParseExact(timeOut, "MM/dd/yyyy HH:mm:ss", null) : DateTime.MaxValue;
            this.semester = !string.IsNullOrEmpty(semester) ? semester : "";
            this.status = Validate.number_string(status) && status == "1" ? true : false;
            this.classNum = classNum;
            this.classType = classType;
        }

    }

   


}
