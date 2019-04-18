using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace MathLib
{
    public class DConnect
    {

        #region Variables

        private string connectionName = "";
        private string connectionString = "";
        private SQLiteConnection dbConnection;
        private DataTable dtAll;
        private DataTable dtIn;
        private DataTable dtUsers;
        private DataTable dtTutors;
        private DataTable dtSettings;
        private static readonly object MainLock = new object();
        private static readonly object UpdateLock = new object();
        private static DConnect instance;
       

        #endregion

        #region Properties
        // This is a singleton class...
        public static DConnect Connection
        {
            get
            {
                lock (MainLock)
                {
                    if (instance == null)
                    {
                        instance = new DConnect();
                    }
                    return instance;
                }
            }

        }

        // User can get the connection name
        public string ConnectionName
        {
            get => connectionName;
            set => this.connectionName = value;
        }


        public string ConnectionString
        {
            get => connectionString;

        }

        public DConnect()
        {

        }

        public DConnect(string connectionName)
        {
            this.connectionName = connectionName;
        }

        #endregion

        #region Constructor
        /// <summary>
        /// The public connection interface
        /// </summary>
        public void Connect()
        {
            connect();
         


        }

        

        #endregion

        #region DBFunctions

        /// <summary>
        /// Open a asynchronous connection and make sure it succeeds
        /// Create the tables if they do not exist and just open the connection
        /// if they do
        /// </summary>
        private void connect()
        {
            try
            {


                if (!File.Exists(connectionName))
                {
                    SQLiteConnection.CreateFile(ConnectionName);


                    string createStudents = @"CREATE TABLE Students (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    StudentID INTEGER UNIQUE NOT NULL,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL,
                                    ClassType TEXT NOT NULL,
                                    ClassNum TEXT NOT NULL,
                                    NumVisits TEXT NOT NULL,
                                    TotalTime TEXT NOT NULL,
                                    TimeStamp TEXT NOT NULL,
                                    Semester TEXT NOT NULL);";

                    string createVisits = @"CREATE TABLE Visits (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    StudentID INTEGER NOT NULL,
                                    Status TEXT NOT NULL,
                                    Semester TEXT NOT NULL,
                                    Tutors TEXT NOT NULL,
                                    ClassNum TEXT NOT NULL,
                                    ClassType TEXT NOT NULL,
                                    Comments TEXT NOT NULL,
                                    TimeStampIn TEXT NOT NULL,
                                    TimeStampOut TEXT NOT NULL);";


                    string createUsers = @"CREATE TABLE Users (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    StudentID INTEGER UNIQUE NOT NULL,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL,
                                    PasswordHash TEXT NOT NULL,
                                    UserTime TEXT NOT NULL,
                                    Admin TEXT NOT NULL,
                                    TimeStamp TEXT NOT NULL);";


                    string createTutors = @"CREATE TABLE Tutors (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    StudentID INTEGER UNIQUE NOT NULL,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL,
                                    Semester TEXT NOT NULL,
                                    TutorTime TEXT NOT NULL,
                                    TimeStamp TEXT NOT NULL);";

                    string createSettings = @"CREATE TABLE Settings (
                                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    SettingName UNIQUE NOT NULL,
                                    SettingValue NOT NULL);";

                    // Then create the actual tables
                    connectionString = @"Data Source=" + ConnectionName + ";Version=3;";
                    dbConnection = new SQLiteConnection(connectionString);
                    dbConnection.Open();

                    SQLiteCommand cmd = new SQLiteCommand(createStudents, dbConnection);
                    cmd.ExecuteNonQuery();

                    SQLiteCommand cmdTwo = new SQLiteCommand(createVisits, dbConnection);
                    cmdTwo.ExecuteNonQuery();

                    SQLiteCommand cmdThree = new SQLiteCommand(createUsers, dbConnection);
                    cmdThree.ExecuteNonQuery();

                    SQLiteCommand cmdFour = new SQLiteCommand(createTutors, dbConnection);
                    cmdFour.ExecuteNonQuery();

                    SQLiteCommand cmdFive = new SQLiteCommand(createSettings, dbConnection);
                    cmdFive.ExecuteNonQuery();

                }
                else
                {
                    connectionString = @"Data Source=" + ConnectionName + ";Version=3;";
                    dbConnection = new SQLiteConnection(connectionString);
                    // Open the async connection
                    dbConnection.Open();
                }


                Logger.Instance.WriteLog("DEBUG", dbConnection.State.ToString());
                FillSet();


            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - connect] " + ex.Message);

            }
        }

        // For each thread in the thread storage wait until it dies...
        // A max of 5 seconds and then just skip that
        
        public void ShutDown()
        {
            try
            {
               
                dbConnection.Close();
                Environment.Exit(Environment.ExitCode);

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - ShutDown] " + ex.Message);
            }
         
        }
        /// <summary>
        /// Load the data set into memory for ease of access
        /// </summary>
        private void FillSet()
        {
            string selectAll = "SELECT * FROM Students";
            string selectIn = "SELECT * FROM Visits";
            string selectUsers = "SELECT * FROM Users";
            string selectTutors = "SELECT * FROM Tutors";
            string selectSettings = "SELECT * FROM Settings";

            dtAll = new DataTable();
            dtIn = new DataTable();
            dtUsers = new DataTable();
            dtTutors = new DataTable();
            dtSettings = new DataTable();

            SQLiteDataAdapter adapterAll = new SQLiteDataAdapter(selectAll, dbConnection);
            SQLiteDataAdapter adapterIn = new SQLiteDataAdapter(selectIn, dbConnection);

            SQLiteDataAdapter adapterUser = new SQLiteDataAdapter(selectUsers, dbConnection);
            SQLiteDataAdapter adapterTutor = new SQLiteDataAdapter(selectTutors, dbConnection);
            SQLiteDataAdapter adapterSettings = new SQLiteDataAdapter(selectSettings, dbConnection);

            adapterAll.Fill(dtAll);
            adapterIn.Fill(dtIn);
            adapterUser.Fill(dtUsers);
            adapterTutor.Fill(dtTutors);
            adapterSettings.Fill(dtSettings);


            dtAll.Columns["id"].AutoIncrement = true;
            dtAll.Columns["id"].AutoIncrementStep = 1;
            if(dtAll.Rows.Count == 0)
            {
                dtAll.Columns["id"].AutoIncrementSeed = 0;
            }
            else
            {
                dtAll.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dtAll.Compute("max([id])", string.Empty)) + 1;
            }
           
            dtIn.Columns["id"].AutoIncrement = true;
            dtIn.Columns["id"].AutoIncrementStep = 1;
            if (dtIn.Rows.Count == 0)
            {
                dtIn.Columns["id"].AutoIncrementSeed = 0;
            }
            else
            {
                dtIn.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dtIn.Compute("max([id])", string.Empty)) + 1;
            }
           
            dtUsers.Columns["id"].AutoIncrement = true;
            dtUsers.Columns["id"].AutoIncrementStep = 1;
            if (dtUsers.Rows.Count == 0)
            {
                dtUsers.Columns["id"].AutoIncrementSeed = 0;
            }
            else
            {
                dtUsers.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dtUsers.Compute("max([id])", string.Empty)) + 1;
            }
            
            dtTutors.Columns["id"].AutoIncrement = true;
            dtTutors.Columns["id"].AutoIncrementStep = 1;
            if (dtTutors.Rows.Count == 0)
            {
                dtTutors.Columns["id"].AutoIncrementSeed = 0;
            }
            else
            {
                dtTutors.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dtTutors.Compute("max([id])", string.Empty)) + 1;
            }
            
            dtSettings.Columns["id"].AutoIncrement = true;
            dtSettings.Columns["id"].AutoIncrementStep = 1;
            if (dtSettings.Rows.Count == 0)
            {
                dtSettings.Columns["id"].AutoIncrementSeed = 0;
            }
            else
            {
                dtSettings.Columns["id"].AutoIncrementSeed = Convert.ToInt32(dtSettings.Compute("max([id])", string.Empty));
            }

            

        }



      

        // Creates an update thread
        // Best used on multicore systems
      
        // If there are no threads then add one to the queue
        // Only allow one thread in the queue at a time...
        public void UpdateDirectly()
        {

            //Thread t = new Thread(new ThreadStart(UpdateConnection));
            //t.Name = "Update Thread";
            //t.IsBackground = true;
            //t.Start();

            UpdateConnection();
            
            
        }

        private void UpdateConnection()
        {
            try
            {
                lock(UpdateLock)
                {
                    // Excecute the next section of code
                    string selectAll = "SELECT * FROM Students WHERE 1 = 0";
                    string selectIn = "SELECT * FROM Visits WHERE 1 = 0";
                    string selectUsers = "SELECT * FROM Users WHERE 1 = 0";
                    string selectTutors = "SELECT * FROM Tutors WHERE 1 = 0";
                    string selectSettings = "SELECT * FROM Settings WHERE 1 = 0";

                    SQLiteDataAdapter adapterAll = new SQLiteDataAdapter(selectAll, dbConnection);
                    SQLiteDataAdapter adapterIn = new SQLiteDataAdapter(selectIn, dbConnection);
                    SQLiteDataAdapter adapterUser = new SQLiteDataAdapter(selectUsers, dbConnection);
                    SQLiteDataAdapter adapterTutor = new SQLiteDataAdapter(selectTutors, dbConnection);
                    SQLiteDataAdapter adapterSettings = new SQLiteDataAdapter(selectSettings, dbConnection);


                    adapterAll.ContinueUpdateOnError = true;
                    adapterIn.ContinueUpdateOnError = true;
                    adapterUser.ContinueUpdateOnError = true;
                    adapterTutor.ContinueUpdateOnError = true;
                    adapterSettings.ContinueUpdateOnError = true;

                    adapterAll.AcceptChangesDuringUpdate = true;
                    adapterIn.AcceptChangesDuringUpdate = true;
                    adapterUser.AcceptChangesDuringUpdate = true;
                    adapterTutor.AcceptChangesDuringUpdate = true;
                    adapterSettings.AcceptChangesDuringUpdate = true;
                   

                    SQLiteCommandBuilder all = new SQLiteCommandBuilder(adapterAll);
                    all.ConflictOption = ConflictOption.OverwriteChanges;
                    all.GetInsertCommand();
                    all.GetUpdateCommand();
                    all.GetDeleteCommand();

                    SQLiteCommandBuilder visit = new SQLiteCommandBuilder(adapterIn);
                    visit.ConflictOption = ConflictOption.OverwriteChanges;
                    visit.GetInsertCommand();
                    visit.GetUpdateCommand();
                    visit.GetDeleteCommand();

                    SQLiteCommandBuilder user = new SQLiteCommandBuilder(adapterUser);
                    user.ConflictOption = ConflictOption.OverwriteChanges;
                    user.GetInsertCommand();
                    user.GetUpdateCommand();
                    user.GetDeleteCommand();

                    SQLiteCommandBuilder tutor = new SQLiteCommandBuilder(adapterTutor);
                    tutor.ConflictOption = ConflictOption.OverwriteChanges;
                    tutor.GetInsertCommand();
                    tutor.GetUpdateCommand();
                    tutor.GetDeleteCommand();

                    SQLiteCommandBuilder settings = new SQLiteCommandBuilder(adapterSettings);
                    settings.ConflictOption = ConflictOption.OverwriteChanges;
                    settings.GetInsertCommand();
                    settings.GetUpdateCommand();
                    settings.GetDeleteCommand();

                    SQLiteCommand command = new SQLiteCommand(dbConnection);
                    
                  
                    adapterAll.Update(dtAll);
                    adapterIn.Update(dtIn);
                    adapterUser.Update(dtUsers);
                    adapterTutor.Update(dtTutors);
                    adapterSettings.Update(dtSettings);

                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateConnection] " + ex.Message);
            }
        }

 

        /// <summary>
        /// Will create a backup of the DB and puts it somewhere else
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CreateBackup(string path)
        {
            bool success = false;
            try
            {
              
              
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - CreateBackup ] " + ex.Message);
            }
            return success;
        }

        #endregion

        #region Helper
        
      

        private string FixString(string broken)
        {
            string result = broken.Trim().ToUpper();
            result = result.Replace("'", "''");
            result = result.Replace("\"", "");
            return result;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// Add a new student record to the DB
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="id"></param>
        /// <param name="classType"></param>
        /// <param name="num"></param>
        public bool AddStudent(string fname, string lname, string id, string classType, string num)
        {
            bool success = false;
            try
            {
                string FirstName = FixString(fname);
                string LastName = FixString(lname);
                UInt64 ID = Convert.ToUInt64(FixString(id));
                string ct = FixString(classType);
                string cn = FixString(num);
                string stamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                string visits = "0";
                string totalTime = "0";

                // Create the new row
                DataRow dr = dtAll.NewRow();

                // Fill the row
                dr["StudentID"] = ID;
                dr["FirstName"] = FirstName;
                dr["LastName"] = LastName;
                dr["ClassType"] = ct;
                dr["ClassNum"] = cn;
                dr["NumVisits"] = visits;
                dr["TotalTime"] = totalTime;
                dr["TimeStamp"] = stamp;
                dr["Semester"] = Lib.GetSemester();

                // Add it to the table
                dtAll.Rows.Add(dr);

                // And update the actual database
                UpdateDirectly();

                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - AddStudent] " + ex.Message);
            }

            return success;
        }


        /// <summary>
        /// Add a setting_name with a value val (true/false)
        /// </summary>
        /// <param name="setting_name"></param>
        /// <param name="val"></param>
        public void AddSetting(string setting_name, bool val = false)
        {
            try
            {
                DataRow setting = dtSettings.NewRow();
                setting["SettingName"] = FixString(setting_name);
                setting["SettingValue"] = val ? "true" : "false";
                dtSettings.Rows.Add(setting);
                UpdateDirectly();
            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - AddSetting] " + ex.Message);
            }
        }


        /// <summary>
        /// Add a user to the dtUsers table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(string id, string fname, string lname , string password)
        {
            bool success = false;
            try
            {
                string FirstName = FixString(fname);
                string LastName = FixString(lname);
                UInt64 ID = Convert.ToUInt64(FixString(id));
                string stamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                string pass = Lib.Get256Hash(password);
                string userTime = "0";
                // Create the new row
                DataRow dr = dtUsers.NewRow();

                // Fill the row
                dr["StudentID"] = ID;
                dr["FirstName"] = FirstName;
                dr["LastName"] = LastName;
                dr["PasswordHash"] = pass;
                dr["UserTime"] = userTime;
                dr["TimeStamp"] = stamp;
               
                // Add it to the table
                dtUsers.Rows.Add(dr);

                // And update the actual database
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - AddUser] " + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Add a tutor to the dtTutor table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <returns></returns>
        public bool AddTutor(string id, string fname, string lname) 
        {
            bool success = false;
            try
            {
                string FirstName = FixString(fname);
                string LastName = FixString(lname);
                UInt64 ID = Convert.ToUInt64(FixString(id));
                string stamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                string tutorTime = "0";
                string semester = Lib.GetSemester();

                // Create the new row
                DataRow dr = dtTutors.NewRow();

                // Fill the row
                dr["StudentID"] = ID;
                dr["FirstName"] = FirstName;
                dr["LastName"] = LastName;

                dr["TutorTime"] = tutorTime;
                dr["TimeStamp"] = stamp;
                dr["Semester"] = Lib.GetSemester();

                // Add it to the table
                dtTutors.Rows.Add(dr);

                // And update the actual database
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - AddTutor] " + ex.Message);
            }
            return success;
        }
        #endregion

        #region DeleteFunctions

        /// <summary>
        /// Delete students by name
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        public bool DeleteStudentByName(string first, string last)
        {
            bool success = false;
            try
            {
              

                foreach (DataRow row in dtAll.Rows)
                {
                    if (row["FirstName"].ToString().Equals(FixString(first)) && row["LastName"].ToString().Equals(FixString(last)))
                    {
                        row.Delete();
                    }
                }


                foreach (DataRow row in dtIn.Rows)
                {
                    if (row["FirstName"].ToString().Equals(FixString(first)) && row["LastName"].ToString().Equals(FixString(last)))
                    {
                        row.Delete();
                    }
                }

                // Create a new thread and update as needed!
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - DeleteStudentByName] " + ex.Message);
            }
            return success;

        }


        /// <summary>
        /// Delete the student record by ID
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteStudentByID(string id)
        {
            bool success = false;
            // Do I want to delete visits??
            try
            {
               
                foreach (DataRow row in dtAll.Rows)
                {
                    if (row["StudentID"].ToString().Equals(FixString(id)))
                    {
                        row.Delete();
                    }
                }


                foreach (DataRow row in dtIn.Rows)
                {
                    if (row["StudentID"].ToString().Equals(FixString(id)))
                    {
                        row.Delete();
                    }
                }




                // Create a new thread and update as needed!
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - DeleteStudentByID] " + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Delete a tutor by id from the dtTutor table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTutorByID(string id)
        {
            bool success = false;
            try
            {
                string selectString = "StudentID = " + FixString(id);
                foreach(DataRow row in dtTutors.Rows)
                {
                    if(row["StudentID"].ToString().Equals(FixString(id)))
                    {
                        row.Delete();
                    }
                }
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - DeleteTutorByID] " + ex.Message);
            }
            return success;
        }
         public bool DeleteUserByID(string id)
         {
            bool success = false;
            try
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    if (row["StudentID"].ToString().Equals(FixString(id)))
                    {
                        row.Delete();
                    }
                }
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - DeleteUserByID] " + ex.Message);
            }
            return success;
        }

        #endregion

        #region SearchFunctions

        // These should not have an update statement.....


            /// <summary>
            /// Return the visits linked to the ID, checked in and out
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public DataRow[] GetVisitsByID(string id)
        {
            List<DataRow> rows = new List<DataRow>();

            try
            {
                // Get all the visits by the selected ID
                string select = "StudentID = " + FixString(id);
                DataRow[] results = dtIn.Select(select);
                rows.AddRange(results);

            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetVisitsByID] " + ex.Message);
            }

            return rows.ToArray();
        }


        /// <summary>
        /// Get the class type of a student byID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetClassTypeByID(string id)
        {
            string ret = "";
            try
            {
                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    ret = dr[0]["ClassType"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetClassTypeByID] " + ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// Get a students class num by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetClassNumByID(string id)
        {
            string ret = "";
            try
            {
                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    ret = dr[0]["ClassNum"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetClassNumByID] " + ex.Message);
            }
            return ret;
        }


        /// <summary>
        /// Return a current student record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CurrentStudentRecord GetCheckedInStudentByID(string id)
        {
            
            UInt64 ID = 0;
            string status = "";
            string tutors= "";
            string stampIn = "";
            string stampOut = "";
            string semester = "";
            string classType = "";
            string classNum = "";
            try
            {
                string selectString = "StudentID = " + FixString(id) + " AND Status = '1'";
                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    
                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    status = dr[0]["Status"].ToString();
                    tutors = dr[0]["Tutors"].ToString();
                    stampIn = dr[0]["TimeStampIn"].ToString();
                    stampOut = dr[0]["TimeStampOut"].ToString();
                    semester = dr[0]["Semester"].ToString();
                    classType = dr[0]["ClassType"].ToString();
                    classNum = dr[0]["ClassNum"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetCheckedInStudentByID] " + ex.Message);
            }

            return new CurrentStudentRecord(this.GetRecordByID(id), ID, tutors, stampIn, stampOut, semester, status, classType, classNum);
        }


        /// <summary>
        /// Grabs the current checked in student with an id and row id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public CurrentStudentRecord GetCheckedInStudentByID(string id, string visitID)
        {

            UInt64 ID = 0;
            string status = "";
            string tutors = "";
            string stampIn = "";
            string stampOut = "";
            string semester = "";
            string classType = "";
            string classNum = "";
            try
            {
                string selectString = "id = " + visitID + " AND StudentID = " + FixString(id) + " AND Status = '0'";
                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {

                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    status = dr[0]["Status"].ToString();
                    tutors = dr[0]["Tutors"].ToString();
                    stampIn = dr[0]["TimeStampIn"].ToString();
                    stampOut = dr[0]["TimeStampOut"].ToString();
                    semester = dr[0]["Semester"].ToString();
                    classType = dr[0]["ClassType"].ToString();
                    classNum = dr[0]["ClassNum"].ToString();
                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetCheckedInStudentByID] " + ex.Message);
            }

            return new CurrentStudentRecord(this.GetRecordByID(id), ID, tutors, stampIn, stampOut, semester, status, classType, classNum);
        }


        /// <summary>
        /// Grabs a crurrent checked in student by first and last name
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public CurrentStudentRecord GetCheckedInStudentByName(string first, string last)
        {
            UInt64 ID = 0;
            string status = "";
            string tutors = "";
            string stampIn = "";
            string stampOut = "";
            string semester = "";
            string classType = "";
            string classNum = "";
            try
            {
                // Select a student from the dtAll table
                //..Fill the datarow
                //..Then create a student record and return it
                string selectString = "";
                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
                {
                    selectString += "FirstName = '" + FixString(first) + "' AND LastName = '" + FixString(last) + "'";
                }
                else
                {
                    if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
                    {
                        selectString += "FirstName = '" + FixString(first) + "'";
                    }
                    else
                    {
                        selectString += "LastName = '" + FixString(last) + "'";
                    }
                }

                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {

                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    status = dr[0]["Status"].ToString();
                    tutors = dr[0]["Tutors"].ToString();
                    stampIn = dr[0]["TimeStampIn"].ToString();
                    stampOut = dr[0]["TimeStampOut"].ToString();
                    semester = dr[0]["Semester"].ToString();
                    classType = dr[0]["ClassType"].ToString();
                    classNum = dr[0]["ClassNum"].ToString();
                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetCheckedInStudentByName] " + ex.Message);
            }

            return new CurrentStudentRecord(this.GetRecordByID(ID.ToString()), ID, tutors, stampIn, stampOut, semester, status, classType, classNum);
        }


        /// <summary>
        /// Is the student checked in?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsCheckedIn(string id)
        {
            bool isCheckedIn = false;
            string status = "";
            try
            {
                string selectString = "StudentID = " + FixString(id) + " AND Status = '1'";
                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    status = dr[0]["Status"].ToString();
                }
                isCheckedIn = status == "1" ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - IsCheckedIn] " + ex.Message);
            }
            return isCheckedIn;
        }

        /// <summary>
        /// is the student checked in by name
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public bool IsCheckedIn(string first, string last)
        {
            bool isCheckedIn = false;
            string status = "";
            try
            {
                string selectString = "";
                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
                {
                    selectString += "FirstName = '" + FixString(first) + "' AND LastName = '" + FixString(last) + "'";
                }
                else
                {
                    if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
                    {
                        selectString += "FirstName = '" + FixString(first) + "'";
                    }
                    else
                    {
                        selectString += "LastName = '" + FixString(last) + "'";
                    }
                }

                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    status = dr[0]["Status"].ToString();
                }

                isCheckedIn = status == "1" ? true : false;

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - IsCheckedIn] " + ex.Message);
            }
            return isCheckedIn;
        }


        public DataTable All()
        {
            return dtAll.Copy();
        }

        public DataTable Visits()
        {
            return dtIn.Copy();
        }

        public DataTable Users()
        {
            return dtUsers.Copy();
        }

        public DataTable Tutors()
        {
            return dtTutors.Copy();
        }

        /// <summary>
        /// Get the student record by name
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public StudentRecord GetRecordBySearchString(string searcher, out bool isGood)
        {
            bool success = false;
            string FirstName = "";
            string LastName = "";
            UInt64 ID = 0;
            string ct = "";
            string cn = "";
            string stamp = "";
            string visits = "";
            string totalTime = "";
            string semester = "";
            try
            {
                // Select a student from the dtAll table
                //..Fill the datarow
                //..Then create a student record and return it
               

                DataRow[] dr = dtAll.Select(searcher);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    FirstName = dr[0]["FirstName"].ToString();
                    LastName = dr[0]["LastName"].ToString();
                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    ct = dr[0]["ClassType"].ToString();
                    cn = dr[0]["ClassNum"].ToString();
                    visits = dr[0]["NumVisits"].ToString();
                    totalTime = dr[0]["TotalTime"].ToString();
                    stamp = dr[0]["TimeStamp"].ToString();
                    semester = dr[0]["Semester"].ToString();
                    success = true;
                }
                else
                {
                    success = false;
               
                }


            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetRecordBySearchString] " + ex.Message);
            }

            isGood = success;

            return new StudentRecord(ID, ct, cn, FirstName, LastName, visits, totalTime, stamp, semester);
        }


        /// <summary>
        /// Get the student record by name
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public StudentRecord GetRecordByName(string first, string last)
        {
            string FirstName = "";
            string LastName = "";
            UInt64 ID = 0;
            string ct = "";
            string cn = "";
            string stamp = "";
            string visits = "";
            string totalTime = "";
            string semester = "";
            try
            {
                // Select a student from the dtAll table
                //..Fill the datarow
                //..Then create a student record and return it
                string selectString = "";
                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(last))
                {
                    selectString += "FirstName = '" + FixString(first) + "' AND LastName = '" + FixString(last) + "'";
                }
                else
                {
                    if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
                    {
                        selectString += "FirstName = '" + FixString(first) + "'";
                    }
                    else
                    {
                        selectString += "LastName = '" + FixString(last) + "'";
                    }
                }

                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    FirstName = dr[0]["FirstName"].ToString();
                    LastName = dr[0]["LastName"].ToString();
                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    ct = dr[0]["ClassType"].ToString();
                    cn = dr[0]["ClassNum"].ToString();
                    visits = dr[0]["NumVisits"].ToString();
                    totalTime = dr[0]["TotalTime"].ToString();
                    stamp = dr[0]["TimeStamp"].ToString();
                    semester = dr[0]["Semester"].ToString();
                }


            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetRecordByName] " + ex.Message);
            }

            return new StudentRecord(ID, ct, cn, FirstName, LastName, visits, totalTime, stamp, semester);
        }


        /// <summary>
        /// Does the student record exist??  Prevents double add
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool StudentExists(string id)
        {
            bool isThere = false;
            try
            {
                // Select a student from the dtAll table
                //..Fill the datarow
                //..Then create a student record and return it
                string selectString = "StudentID = " + FixString(id);

                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    isThere = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - StudentExists] " + ex.Message);
            }
            return isThere;
        }


        /// <summary>
        /// Get the student record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentRecord GetRecordByID(string id)
        {
            string FirstName = "";
            string LastName = "";
            UInt64 ID = 0;
            string ct = "";
            string cn = "";
            string stamp = "";
            string visits = "";
            string totalTime = "";
            string semester = "";

            try
            {
                // Select a student from the dtAll table
                //..Fill the datarow
                //..Then create a student record and return it
                string selectString = "StudentID = " + FixString(id);

                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    FirstName = dr[0]["FirstName"].ToString();
                    LastName = dr[0]["LastName"].ToString();
                    ID = Convert.ToUInt64(dr[0]["StudentID"].ToString());
                    ct = dr[0]["ClassType"].ToString();
                    cn = dr[0]["ClassNum"].ToString();
                    visits = dr[0]["NumVisits"].ToString();
                    totalTime = dr[0]["TotalTime"].ToString();
                    stamp = dr[0]["TimeStamp"].ToString();
                    semester = dr[0]["Semester"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetRecordByID] " + ex.Message);
            }

            return new StudentRecord(ID, ct, cn, FirstName, LastName, visits, totalTime, stamp, semester);
        }


        /// <summary>
        /// Gets all the tutors names
        /// </summary>
        /// <returns></returns>
        public Tutor[] GetAllTutors()
        {
            Tutor[] temp = null;
            try
            {
              temp = new Tutor[dtTutors.Rows.Count];
              int i = 0;
              foreach(DataRow row in dtTutors.Rows)
              {
                    temp[i].firstName = row["FirstName"].ToString();
                    temp[i].lastName = row["LastName"].ToString();
                    temp[i].tutorID = row["StudentID"].ToString();
                    temp[i].semester = row["Semester"].ToString();
                    temp[i].tutorTime = row["TutorTime"].ToString();
                    temp[i].timeStamp = Validate.strict_date(row["TimeStamp"].ToString()) ? DateTime.ParseExact(row["TimeStamp"].ToString(), "MM/dd/yyyy HH:mm:ss", null) : DateTime.Now;

                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetAllTutors] " + ex.Message);
            }
            return temp;
        }


        /// <summary>
        /// Gets the visits table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetVisitTable(string id)
        {
            DataTable temp = dtIn.Copy();
            temp.Clear();
            DataRow[] selected = dtIn.Select("StudentID = " + id + " AND Status = '0'");
            if(selected.Length > 0)
            {
                temp = selected.CopyToDataTable();
            }
          
            return temp;
        }

        /// <summary>
        /// Merges the changes returned after being modified
        /// </summary>
        /// <param name="toMerge"></param>
        /// <returns></returns>
        public bool MergeVisits(DataTable toMerge)
        {
            bool isSuccess = false;
            try
            {
                // Make sure time is updated on any changes as well
                foreach(DataRow row in toMerge.Rows)
                {
                    foreach(DataRow innerRow in dtIn.Rows)
                    {
                        if(row["id"].ToString() == innerRow["id"].ToString())
                        {
                            innerRow["Tutors"] = row["Tutors"].ToString();
                            innerRow["Comments"] = row["Comments"].ToString();
                            string student = innerRow["StudentID"].ToString();
                            string oldTimeIn = innerRow["TimeStampIn"].ToString();
                            string oldTimeOut = innerRow["TimeStampOut"].ToString();
                            UInt64 oldOut = Lib.FixTime(DateTime.ParseExact(oldTimeOut, "MM/dd/yyyy HH:mm:ss", null));
                            UInt64 oldIn = Lib.FixTime(DateTime.ParseExact(oldTimeIn, "MM/dd/yyyy HH:mm:ss", null));
                            UInt64 removeTime = oldOut - oldIn;
                            UpdateTotalTimeByAmount(student, removeTime, true);    // Subtract Time
                            innerRow["TimeStampIn"] = row["TimeStampIn"].ToString();
                            innerRow["TimeStampOut"] = row["TimeStampOut"].ToString();
                            string newTimeIn = innerRow["TimeStampIn"].ToString();
                            string newTimeOut = innerRow["TimeStampOut"].ToString();
                            UInt64 newOut = Lib.FixTime(DateTime.ParseExact(newTimeOut, "MM/dd/yyyy HH:mm:ss", null));
                            UInt64 newIn = Lib.FixTime(DateTime.ParseExact(newTimeIn, "MM/dd/yyyy HH:mm:ss", null));
                            UInt64 addTime = newOut - newIn;
                            UpdateTotalTimeByAmount(student, addTime);    // Add Time
                        }
                    }
                }
                isSuccess = true;
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - MergeVisits] " + ex.Message);
            }
            return isSuccess;
        }

        public void saveComment(string id, string comment)
        {
            try
            {
                DataRow[] rows = dtIn.Select("StudentID = " + id + " AND Status = '1'");
                if (rows.Length > 0 && rows.Length < 2)
                {

                    rows[0]["Comments"] = comment;
                }
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - saveComment] " + ex.Message);
            }
        }

        public string getComment(string id)
        {
            string res = "";
            try
            {
                DataRow[] rows = dtIn.Select("StudentID = " + id + " AND Status = '1'");
                if (rows.Length > 0 && rows.Length < 2)
                {

                    res = rows[0]["Comments"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - getComment] " + ex.Message);
            }
            return res;
        }


        public string getCommentByNum(string id, string visit)
        {
            string res = "";
            try
            {
                DataRow[] rows = dtIn.Select("StudentID = " + id + " AND id = " + visit);
                if (rows.Length > 0 && rows.Length < 2)
                {

                    res = rows[0]["Comments"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - getCommentByNum] " + ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Save a new student record with the changes
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        public void SaveStudentRecord(StudentRecord student, string id)
        {
            try
            {

                DataRow[] rows = dtAll.Select("StudentID = " + id);
                if (rows.Length > 0 && rows.Length < 2)
                {
                    // Then edit the row
                    rows[0]["StudentID"] = student.studentID;
                    rows[0]["FirstName"] = student.firstName;
                    rows[0]["LastName"] = student.lastName;
                    rows[0]["Semester"] = student.semester;
                    rows[0]["ClassNum"] = student.classNum;
                    rows[0]["ClassType"] = student.classType;


                    // Fix the visit rows as well
                    foreach (DataRow row in dtIn.Select("StudentID = " + id))
                    {
                        row["StudentID"] = student.studentID;
                        row["FirstName"] = student.firstName;
                        row["LastName"] = student.lastName;
                    }

                    UpdateDirectly();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - SaveStudentRecord] " + ex.Message);
            }
        }

        /// <summary>
        /// Get semester choices in the DB
        /// </summary>
        /// <returns></returns>
        public string[] GetSemesterChoices()
        {
            HashSet<string> semesters = new HashSet<string>();
            try
            {

                foreach (DataRow row in dtAll.Rows)
                {
                    semesters.Add(row["Semester"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetSemesterChoices] " + ex.Message);
            }
            String[] array = new string[semesters.Count];
            semesters.CopyTo(array);
            return array;
        }

        /// <summary>
        /// Does the student have the tutor
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public bool StudentHasTutor(string student_id, string first, string last)
        {
            bool success = false;
            try
            {
                string select = "StudentID = " + FixString(student_id) + " AND Status = '1'";
                DataRow[] temp = dtIn.Select(select);
                if(temp.Length < 2 && temp.Length > 0)
                {
                    string row = temp[0]["Tutors"].ToString();
                    foreach(string s in row.Split(','))
                    {
                        if(s.Contains(FixString(first)) && s.Contains(FixString(last)))
                        {
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - StudentHasTutor] " + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Does the student have the tutor at a specific ID
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="visitid"></param>
        /// <returns></returns>
        public bool StudentHasTutor(string student_id, string first, string last, string visitid)
        {
            bool success = false;
            try
            {
                string select = "id = " + visitid + " AND StudentID = " + FixString(student_id) + " AND Status = '0'";
                DataRow[] temp = dtIn.Select(select);
                if (temp.Length < 2 && temp.Length > 0)
                {
                    string row = temp[0]["Tutors"].ToString();
                    foreach (string s in row.Split(','))
                    {
                        if (s.Contains(FixString(first)) && s.Contains(FixString(last)))
                        {
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - StudentHasTutor] " + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Get tutor by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tutor GetTutorByID(string id)
        {

            string fname = "";
            string lname = "";
            UInt64 ID = 0;
            string stamp = "";
            string semester = "";
            string tutorTime = "";

            try
            {
                string select = "StudentID = " + FixString(id);
                DataRow[] temp = dtTutors.Select(select);
                if (temp.Length < 2 && temp.Length > 1)
                {
                    ID = Convert.ToUInt64(temp[0]["StudentID"].ToString());
                    fname = temp[0]["FirstName"].ToString();
                    lname = temp[0]["LastName"].ToString();
                    tutorTime = temp[0]["TutorTime"].ToString();
                    semester = temp[0]["Semester"].ToString();
                    stamp = temp[0]["TimeStamp"].ToString();
                }
            
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - StudentHasTutor] " + ex.Message);
            }
            return new Tutor(ID, fname, lname, tutorTime, stamp, semester);
        }

        /// <summary>
        /// Return a list of users
        /// </summary>
        /// <returns></returns>
        public User[] GetAllUsers()
        {
            User[] temp = null;
            try
            {
                temp = new User[dtUsers.Rows.Count];
                int i = 0;
                foreach (DataRow row in dtUsers.Rows)
                {
                    temp[i].firstName = row["FirstName"].ToString();
                    temp[i].lastName = row["LastName"].ToString();
                    temp[i].userID = row["StudentID"].ToString();
                    temp[i].passwordHash = row["PasswordHash"].ToString();
                    temp[i].userTime = row["UserTime"].ToString();
                    temp[i].timeStamp = Validate.strict_date(row["TimeStamp"].ToString()) ? DateTime.ParseExact(row["TimeStamp"].ToString(), "MM/dd/yyyy HH:mm:ss", null) : DateTime.Now;

                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetAllUsers] " + ex.Message);
            }
            return temp;
        }


        /// <summary>
        /// Check the password hash using SHA256
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUserPass(string id, string password)
        {
            bool success = false;
            try
            {
                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr = dtUsers.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    if(dr[0]["PasswordHash"].ToString().Equals(Lib.Get256Hash(password)))
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
              
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - CheckUserPass] " + ex.Message);
            }
            return success;
        }


        /// <summary>
        /// Get all math students
        /// </summary>
        /// <returns></returns>
        public CurrentStudentRecord[] GetAllMathStudents()
        {
            List<CurrentStudentRecord> list = new List<CurrentStudentRecord>();
            try
            {

                string selectMathFromAll = "ClassType = 'MTH' ";
                DataRow[] students = dtAll.Select(selectMathFromAll);

                string selectCurrent = "Status = '1'";
                DataRow[] current = dtIn.Select(selectCurrent);

                // Sort them out now
                foreach (DataRow row in current)
                {
                    DataRow[] temp = dtAll.Select(selectMathFromAll + "AND StudentID = " + row["StudentID"].ToString());
                    if (temp.Length == 1)
                    {
                        list.Add(new CurrentStudentRecord(
                                                            GetRecordByID(row["StudentID"].ToString()),
                                                             Convert.ToUInt64(row["StudentID"].ToString()),
                                                             row["Tutors"].ToString(),
                                                             row["TimeStampIn"].ToString(),
                                                             row["TimeStampOut"].ToString(),
                                                             row["Semester"].ToString(),
                                                             row["Status"].ToString(),
                                                             row["ClassType"].ToString(),
                                                             row["ClassNum"].ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetAllMathStudents] " + ex.Message);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Get all stat students
        /// </summary>
        /// <returns></returns>
        public CurrentStudentRecord[] GetAllStatisticsStudents()
        {
            List<CurrentStudentRecord> list = new List<CurrentStudentRecord>();
            try
            {


                string selectStatFromAll = "ClassType = 'STAT' ";
                DataRow[] students = dtAll.Select(selectStatFromAll);

                string selectCurrent = "Status = '1'";
                DataRow[] current = dtIn.Select(selectCurrent);

                // Sort them out now
                foreach (DataRow row in current)
                {
                    DataRow[] temp = dtAll.Select(selectStatFromAll + "AND StudentID = " + row["StudentID"].ToString());
                    if (temp.Length == 1)
                    {
                        list.Add(new CurrentStudentRecord(
                                                           GetRecordByID(row["StudentID"].ToString()),
                                                            Convert.ToUInt64(row["StudentID"].ToString()),
                                                            row["Tutors"].ToString(),
                                                            row["TimeStampIn"].ToString(),
                                                            row["TimeStampOut"].ToString(),
                                                            row["Semester"].ToString(),
                                                            row["Status"].ToString(),
                                                            row["ClassType"].ToString(),
                                                            row["ClassNum"].ToString()));
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetAllStatisticStudents] " + ex.Message);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Get all other students
        /// </summary>
        /// <returns></returns>
        public CurrentStudentRecord[] GetAllOtherStudents()
        {
            List<CurrentStudentRecord> list = new List<CurrentStudentRecord>();
            try
            {

                string selectOtherFromAll = "ClassType = 'OTH' ";
                DataRow[] students = dtAll.Select(selectOtherFromAll);

                string selectCurrent = "Status = '1'";
                DataRow[] current = dtIn.Select(selectCurrent);

                // Sort them out now
                foreach (DataRow row in current)
                {
                    DataRow[] temp = dtAll.Select(selectOtherFromAll + "AND StudentID = " + row["StudentID"].ToString());
                    if (temp.Length == 1)
                    {
                        list.Add(new CurrentStudentRecord(
                                                           GetRecordByID(row["StudentID"].ToString()),
                                                            Convert.ToUInt64(row["StudentID"].ToString()),
                                                            row["Tutors"].ToString(),
                                                            row["TimeStampIn"].ToString(),
                                                            row["TimeStampOut"].ToString(),
                                                            row["Semester"].ToString(),
                                                            row["Status"].ToString(),
                                                            row["ClassType"].ToString(),
                                                            row["ClassNum"].ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetAllOtherStudents] " + ex.Message);
            }

            return list.ToArray();
        }


        /// <summary>
        /// Checks if setting exists
        /// </summary>
        /// <param name="setting_name"></param>
        /// <returns></returns>
        public bool HasSetting(string setting_name)
        {
            bool hasSetting = false;
            try
            {
                DataRow[] rows = dtSettings.Select("SettingName = '" + FixString(setting_name) + "'");
                if(rows.Length > 0)
                {
                    hasSetting = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetSetting] " + ex.Message);
            }
            return hasSetting;
        }


        /// <summary>
        /// Gets a string version of the tutors
        /// </summary>
        /// <returns></returns>
       public string[] GetTutorList()
        {
            List<string> tutors = new List<string>();
            try
            {

                foreach (DataRow row in dtTutors.Rows)
                {
                    tutors.Add(row["FirstName"].ToString() + "-" +
                        row["LastName"].ToString() + "-" +
                        row["StudentID"].ToString() );
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetTutorList] " + ex.Message);
            }
            return tutors.ToArray();
        }


        /// <summary>
        /// Sets a setting with a true/false value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetSetting(string name, bool value)
        {
           
            try
            {
                DataRow[] rows = dtSettings.Select("SettingName = '" + FixString(name) + "'");
                if (rows.Length > 0 && rows.Length < 2)
                {
                    rows[0]["SettingValue"] = value ? "true" : "false";
                }
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - SetSetting] " + ex.Message);
            }
           
        }

        /// <summary>
        /// Gets the setting true/false value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetSetting(string name)
        {
            string setting_val = "false";
            try
            {
                setting_val = dtSettings.Select("SettingName = '" + FixString(name) + "'")[0]["SettingValue"].ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetSetting] " + ex.Message);
            }
            return setting_val == "true" ? true : false;
        }

        /// <summary>
        /// Returns the users as a string
        /// </summary>
        /// <returns></returns>
        public string[] GetUserList()
        {
            List<string> users = new List<string>();
            try
            {

                foreach (DataRow row in dtUsers.Rows)
                {
                    users.Add(row["FirstName"].ToString() + "-" +
                        row["LastName"].ToString() + "-" +
                        row["StudentID"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetUserList] " + ex.Message);
            }
            return users.ToArray();
        }


        /// <summary>
        /// Gets the username by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserNameByID(string id)
        {
            string ret = "";
            try
            {
                string first = "";
                string last = "";
                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr = dtUsers.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {

                    first = dr[0]["FirstName"].ToString();
                    last = dr[0]["LastName"].ToString();

                }
                ret = first + " " + last[0] + ".";
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetUserNameByID] " + ex.Message);
            }
            return ret;

        }


        /// <summary>
        /// Get the current class list
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public string[] GetClassList(string ct)
        {
            HashSet<string> class_nums = new HashSet<string>();
            try
            {

                foreach (DataRow row in dtAll.Select("ClassType = '" + FixString(ct) + "'"))
                {
                    class_nums.Add(row["ClassNum"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - GetClassList] " + ex.Message);
            }
            String[] array = new string[class_nums.Count];
            class_nums.CopyTo(array);
            return array;
        }

        #endregion

        #region InAndOut

        /// <summary>
        /// Must checkIn students and is hooked up to a logIN event
        /// </summary>
        /// <param name="id"></param>
        public bool CheckIn(string id)
        {
            bool success = false;
            try
            {
                // To check in...
                // Create a new checkInRow
                // Then get a student record
                // Finally Update the table with a status of 1
                DataRow dr = dtIn.NewRow();
                StudentRecord student = GetRecordByID(id);
                dr["TimeStampIn"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                dr["StudentID"] = Convert.ToUInt64(student.studentID);
                dr["Tutors"] = "";
                dr["Status"] = "1"; // For in
                dr["Semester"] = Lib.GetSemester();
                dr["TimeStampOut"] = "";     // Fill in later
                dr["ClassType"] = student.classType;
                dr["ClassNum"] = student.classNum;
                dtIn.Rows.Add(dr);
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - CheckIn] " + ex.Message);
            }

            return success;

        }

        /// <summary>
        /// Must logout students and is hooked up to a logOUT event
        /// </summary>
        /// <param name="id"></param>
        public bool CheckOut(string id)
        {
            bool success = false;
            try
            {
                // Get the student that is checked in...
                // Add tutors if need be
                // Then set status to 0 
                // then set time out
                // Update total visits and time
                string selectString = "StudentID = " + FixString(id) + " AND Status = '1'";
                DataRow[] dr = dtIn.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                  
                   // dr[0]["Tutors"] = tutors;
                    dr[0]["TimeStampOut"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");


                    // Update Visits and total time
                    UpdateVisits(dr[0]["StudentID"].ToString());
                    UpdateTotalTime(dr[0]["StudentID"].ToString());

                    dr[0]["Status"] = "0";
                }



                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - CheckOut] " + ex.Message);
            }
            return success;
        }


        #endregion

        #region UpdateFunctions

        /// <summary>
        /// Updates the students visits everytime they come in
        /// </summary>
        /// <param name="id"></param>
        public bool UpdateVisits(string id)
        {
            bool success = false;
            try
            {
                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr = dtAll.Select(selectString);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    dr[0]["NumVisits"] = (Convert.ToUInt64(dr[0]["NumVisits"].ToString()) + 1).ToString();
                }
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateVisits] " + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Updates the students visits everytime they come in
        /// </summary>
        /// <param name="id"></param>
        public bool UpdateTotalTime(string id)
        {
            bool success = false;
            try
            {
                UInt64 time = 0;
                string selectCurrent = "StudentID = " + FixString(id) + " AND Status = '1'";
                DataRow[] dr = dtIn.Select(selectCurrent);
                if (dr.Length > 0 && dr.Length < 2)
                {
                    string timeIn = dr[0]["TimeStampIn"].ToString();
                    string timeOut = dr[0]["TimeStampOut"].ToString();
                    UInt64 later = Lib.FixTime(DateTime.ParseExact(timeOut, "MM/dd/yyyy HH:mm:ss", null));
                    UInt64 before = Lib.FixTime(DateTime.ParseExact(timeIn, "MM/dd/yyyy HH:mm:ss", null));
                    time = later - before;
                }

                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr2 = dtAll.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    dr2[0]["TotalTime"] = (Convert.ToUInt64(dr2[0]["TotalTime"].ToString()) + time).ToString();
                }

                // Update tutors times if the student has the tutor...Do this on update as well...


                success = true;
                

            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateTotalTime] " + ex.Message);
            }
            return success;
        }

        public bool UpdateTotalTimeByAmount(string id, UInt64 amount, bool op = false)
        {
            bool success = false;
            try
            {
                

                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr2 = dtAll.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    if(!op)
                        dr2[0]["TotalTime"] = (Convert.ToUInt64(dr2[0]["TotalTime"].ToString()) + amount).ToString();
                    else
                        dr2[0]["TotalTime"] = (Convert.ToUInt64(dr2[0]["TotalTime"].ToString()) - amount).ToString();
                }
                UpdateDirectly();
                success = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateTotalTimeByAmount] " + ex.Message);
            }
            return success;
        }

        public bool UpdateTutorTimeByAmount(string id, UInt64 amount, bool op = false)
        {
            bool success = false;
            try
            {


                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr2 = dtTutors.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    if (!op)
                        dr2[0]["TutorTime"] = (Convert.ToUInt64(dr2[0]["TutorTime"].ToString()) + amount).ToString();
                    else
                        dr2[0]["TutorTime"] = (Convert.ToUInt64(dr2[0]["TutorTime"].ToString()) - amount).ToString();
                }
                success = true;
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateTutorTimeByAmount] " + ex.Message);
            }
            return success;
        }

        public bool UpdateUserTime(string id, string session_start)
        {
            bool success = false;
            try
            {
                UInt64 time = 0;

                string selectString = "StudentID = " + FixString(id);
                DataRow[] dr2 = dtUsers.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    UInt64 later = Lib.FixTime(DateTime.Now);
                    UInt64 before = Lib.FixTime(DateTime.ParseExact(session_start, "MM/dd/yyyy HH:mm:ss", null));
                    time = later - before;
                    dr2[0]["UserTime"] = (Convert.ToUInt64(dr2[0]["UserTime"].ToString()) + time).ToString(); 
                }
                success = true;
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateTotalTimeByAmount] " + ex.Message);
            }
            return success;
        }


        public void RemoveTutorFromStudentByID(string tFirst, string tLast, string student_id)
        {

            try
            {
                string select = "StudentID = " + FixString(student_id) + " AND Status = '1'";
                DataRow[] temp = dtIn.Select(select);
                if (temp.Length < 2 && temp.Length > 0)
                {
                    string row = temp[0]["Tutors"].ToString();
                    if (row.Contains(FixString(tFirst) + " " + FixString(tLast)))
                    {
                        // Try this first...
                        temp[0]["Tutors"] = row.Replace("," + FixString(tFirst) + " " + FixString(tLast), "");
                        temp[0]["Tutors"] = row.Replace(FixString(tFirst) + " " + FixString(tLast), "");
                        if(row.Substring(row.Length - 2).Contains(","))
                        {
                            temp[0]["Tutors"] = row.Remove(row.LastIndexOf(','), 1);
                        }
                    }
                }
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - RemoveTutorFromStudentByID] " + ex.Message);
            }

        }
            public void RemoveTutorFromStudentByID(string tFirst, string tLast, string student_id, string visitNum)
            {

                try
                {
                    string select = "id = " + visitNum + " AND StudentID = " + FixString(student_id) + " AND Status = '0'";
                    DataRow[] temp = dtIn.Select(select);
                    if (temp.Length < 2 && temp.Length > 0)
                    {
                        string row = temp[0]["Tutors"].ToString();
                        if (row.Contains(FixString(tFirst) + " " + FixString(tLast)))
                        {
                            // Try this first...
                            temp[0]["Tutors"] = row.Replace("," + FixString(tFirst) + " " + FixString(tLast), "");
                            temp[0]["Tutors"] = row.Replace(FixString(tFirst) + " " + FixString(tLast), "");
                        if (row.Substring(row.Length - 2).Contains(","))
                        {
                            temp[0]["Tutors"] = row.Remove(row.LastIndexOf(','), 1);
                        }
                    }
                    }
                    UpdateDirectly();
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteLog("FATAL", "[Method - RemoveTutorFromStudentByID] " + ex.Message);
                }

            }

        public bool UpdateStudentTutorList(string id, string tutor, string status)
        {
           
           // will make status 2 when updating to ensure that it knows its updating.....

            bool success = false;
            try
            {
                string t = FixString(tutor);
                string selectString = "StudentID = " + id + " AND Status = '" + status + "'";
                DataRow[] dr2 = dtIn.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    if (string.IsNullOrEmpty(dr2[0]["Tutors"].ToString()))
                    {
                        dr2[0]["Tutors"] = t;
                     
                    }
                    else
                    {
                        dr2[0]["Tutors"] = dr2[0]["Tutors"].ToString() + "," + t;
                    }
                       
                    }

                
                success = true;
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateStudentTutorList] " + ex.Message);
            }
            return success;
        }

        public bool UpdateStudentTutorList(string id, string tutor, string status, string visitNum)
        {

            // will make status 2 when updating to ensure that it knows its updating.....

            bool success = false;
            try
            {
                string t = FixString(tutor);
                string selectString = "id = " + visitNum + " AND StudentID = " + id + " AND Status = '" + status + "'";
                DataRow[] dr2 = dtIn.Select(selectString);
                if (dr2.Length > 0 && dr2.Length < 2)
                {
                    if (string.IsNullOrEmpty(dr2[0]["Tutors"].ToString()))
                    {
                        dr2[0]["Tutors"] = t;

                    }
                    else
                    {
                        dr2[0]["Tutors"] = dr2[0]["Tutors"].ToString() + "," + t;
                    }

                }


                success = true;
                UpdateDirectly();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FATAL", "[Method - UpdateStudentTutorList] " + ex.Message);
            }
            return success;
        }

        #endregion

        #region Aggregates
        /// <summary>
        /// Get the total students in the system
        /// </summary>
        /// <returns></returns>
        public UInt64 GetTotalStudents()
        {
                return (UInt64) dtAll.Rows.Count;
        }


        /// <summary>
        /// Gets all users count
        /// </summary>
        /// <returns></returns>
        public UInt64 GetTotalUsers()
        {
            return (UInt64)dtUsers.Rows.Count;
        }

        /// <summary>
        /// Gets all tutors
        /// </summary>
        /// <returns></returns>
        public UInt64 GetTotalTutors()
        {
            return (UInt64)dtTutors.Rows.Count;
        }

        /// <summary>
        /// Get total visits
        /// </summary>
        /// <returns></returns>
        public UInt64 GetTotalVisits()
        {
            return (UInt64)dtIn.Rows.Count;
        }

        
        /// <summary>
        /// Get time via the students id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTimeViaID(string id)
        {
            DataRow[] temp = dtAll.Select("StudentID = " + id);
            return temp.Length == 1 ? temp[0]["TotalTime"].ToString() : "0";
        }


        /// <summary>
        /// Get visits via the students id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UInt64 GetVisitsViaID(string id)
        {
            DataRow[] temp = dtAll.Select("StudentID = " + id);
            return temp.Length == 1 ? Convert.ToUInt64(temp[0]["NumVisits"].ToString()) : 0;
        }

        /// <summary>
        /// Get students per semester
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        public UInt64 GetStudentsPerSemester(string semester)
        {
            DataRow[] rows = dtAll.Select("Semester = '" + semester + "'");
            return (UInt64)rows.Length;
        }

        public UInt64 GetStudentsPerClassType(string ct)
        {
            DataRow[] rows = dtAll.Select("ClassType = '" + ct + "'");
            return (UInt64)rows.Length;
        }

        public UInt64 GetStudentsPerClassTypePerSemester(string ct, string semester)
        {
            DataRow[] rows = dtAll.Select("ClassType = '" + ct + "'" + " AND Semester = '" + semester + "'");
            return (UInt64)rows.Length;
        }

        /// <summary>
        /// Get visits per semester
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        public UInt64 GetVisitsPerSemester(string semester)
        {
            DataRow[] rows = dtIn.Select("Semester = '" + semester + "'");
            return (UInt64)rows.Length;
        }

        public UInt64 GetTutorTime(string id)
        {
            DataRow[] rows = dtTutors.Select("StudentID = " + id );
            return Convert.ToUInt64(rows[0]["TutorTime"].ToString());
        }

        public UInt64 GetUserTime(string id)
        {
            DataRow[] rows = dtUsers.Select("StudentID = " + id );
            return Convert.ToUInt64(rows[0]["UserTime"].ToString());
        }



        #endregion




    }
}
