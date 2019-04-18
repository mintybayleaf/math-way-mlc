using System;

namespace MathLib
{
    public struct StudentRecord
    {
        public string studentID;
        public string classType;
        public string classNum;
        public string firstName;
        public string lastName;
        public string numVisits;
        public string totalTime;
        public string semester;
        public DateTime timeStamp;

        public StudentRecord(UInt64 id, string classType,string classNum, string fname, string lname, string numVisits, string totalTime, string time, string sem)
        {
            this.studentID = id.ToString();
            this.classType = Validate.letter_string(classType) ? classType : "";
            this.classNum = Validate.number_string(classNum) ? classNum : "";
            this.firstName = Validate.strict_string(fname) ? fname : "";
            this.lastName = Validate.strict_string(lname) ? lname : "";
            this.numVisits = Validate.number_string(numVisits) ? numVisits : "";
            this.totalTime = Validate.number_string(totalTime) ? totalTime : "";
            this.timeStamp = Validate.strict_date(time) ? DateTime.ParseExact(time, "MM/dd/yyyy HH:mm:ss", null) : DateTime.MaxValue;
            this.semester = !string.IsNullOrEmpty(sem) ? sem : "";

        }
        
    }
}
