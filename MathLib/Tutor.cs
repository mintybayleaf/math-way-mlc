using System;

namespace MathLib
{
    public struct Tutor
    {
        public string tutorID;
        public string firstName;
        public string lastName;
        public string tutorTime;
        public string semester;
        public DateTime timeStamp;

        public Tutor(UInt64 id, string fname, string lname, string tutorTime, string time, string semester)
        {
            this.tutorID = id.ToString();
            this.firstName = Validate.strict_string(fname) ? fname : "";
            this.lastName = Validate.strict_string(lname) ? lname : "";
            this.tutorTime = Validate.number_string(tutorTime) ? tutorTime : "";
            this.timeStamp = Validate.strict_date(time) ? DateTime.ParseExact(time, "MM/dd/yyyy HH:mm:ss", null) : DateTime.MaxValue;
            this.semester = !string.IsNullOrEmpty(semester) ? semester : "";

        }

    }
}
