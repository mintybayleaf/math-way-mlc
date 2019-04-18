using System;

namespace MathLib
{
    public struct User
    {
        public string userID;
        public string firstName;
        public string lastName;
        public string userTime;
        public string passwordHash;
        public DateTime timeStamp;

        public User(UInt64 id, string fname, string lname, string userTime, string time, string password)
        {
            this.userID = id.ToString(); 
            this.firstName = Validate.strict_string(fname) ? fname : "";
            this.lastName = Validate.strict_string(lname) ? lname : "";
            this.userTime = Validate.number_string(userTime) ? userTime : "";
            this.timeStamp = Validate.strict_date(time) ? DateTime.ParseExact(time, "MM/dd/yyyy HH:mm:ss", null) : DateTime.MaxValue;
            this.passwordHash = Validate.loose_string(password) ? password : "";

        }
    }
}
