using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Drawing;
using System.IO;


namespace MathLib
{
    public class ReportViewer
    {

        public ReportViewer()
        {

        }

        #region Reports
        public void StudentReport()
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet studentSheet = package.Workbook.Worksheets.Add("Students");
                studentSheet.Cells[1, 2].Value = "TableID";
                studentSheet.Cells[1, 3].Value = "StudentID";
                studentSheet.Cells[1, 4].Value = "First Name";
                studentSheet.Cells[1, 5].Value = "Last Name";
                studentSheet.Cells[1, 6].Value = "Semester";
                studentSheet.Cells[1, 7].Value = "ClassType";
                studentSheet.Cells[1, 8].Value = "ClassNum";
                studentSheet.Cells[1, 9].Value = "Total Mins";
                studentSheet.Cells[1, 10].Value = "Total Visits";
                studentSheet.Cells[1, 11].Value = "DateAdded";

                int rowFrom = 1;
                int rowTo = 1;
                int colStart = 2;
                int colEnd = 11;

                // Set the headers
                using (var range = studentSheet.Cells[rowFrom, colStart, rowTo, colEnd])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.Bold = true;
                }

                // Fill the cells with the database stuffs
                foreach (DataRow row in DConnect.Connection.All().Rows)
                {
                    using (var range = studentSheet.Cells[++rowFrom, colStart, ++rowTo, colEnd])
                    {
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    studentSheet.Cells[rowFrom, 2].Value = row["id"].ToString();
                    studentSheet.Cells[rowFrom, 3].Value = row["StudentID"].ToString();
                    studentSheet.Cells[rowFrom, 4].Value = row["FirstName"].ToString();
                    studentSheet.Cells[rowFrom, 5].Value = row["LastName"].ToString();
                    studentSheet.Cells[rowFrom, 6].Value = row["Semester"].ToString();
                    studentSheet.Cells[rowFrom, 7].Value = row["ClassType"].ToString();
                    studentSheet.Cells[rowFrom, 8].Value = row["ClassNum"].ToString();
                    studentSheet.Cells[rowFrom, 9].Value = row["TotalTime"].ToString();
                    studentSheet.Cells[rowFrom, 10].Value = row["NumVisits"].ToString();
                    studentSheet.Cells[rowFrom, 11].Value = row["TimeStamp"].ToString();

                }

                studentSheet.Cells.AutoFitColumns(0);

                SaveSpreadSheetAs(package, "Students_" + DateTime.Now.GetHashCode(), "Students");
            }
        }

        public void AllVisitReport()
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet studentSheet = package.Workbook.Worksheets.Add("Visits");
                studentSheet.Cells[1, 2].Value = "TableID";
                studentSheet.Cells[1, 3].Value = "StudentID";
                studentSheet.Cells[1, 4].Value = "First Name";
                studentSheet.Cells[1, 5].Value = "Last Name";
                studentSheet.Cells[1, 6].Value = "Semester";
                studentSheet.Cells[1, 7].Value = "ClassType";
                studentSheet.Cells[1, 8].Value = "ClassNum";
                studentSheet.Cells[1, 9].Value = "Tutors";
                studentSheet.Cells[1, 10].Value = "TimeIn";
                studentSheet.Cells[1, 11].Value = "TimeOut";

                int rowFrom = 1;
                int rowTo = 1;
                int colStart = 2;
                int colEnd = 11;

                // Set the headers
                using (var range = studentSheet.Cells[rowFrom, colStart, rowTo, colEnd])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.Bold = true;
                }

                // Fill the cells with the database stuffs
                foreach (DataRow row in DConnect.Connection.Visits().Select("Status = '0'"))
                {
                    using (var range = studentSheet.Cells[++rowFrom, colStart, ++rowTo, colEnd])
                    {
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    studentSheet.Cells[rowFrom, 2].Value = row["id"].ToString();
                    studentSheet.Cells[rowFrom, 3].Value = row["StudentID"].ToString();

                    StudentRecord student = DConnect.Connection.GetRecordByID(row["StudentID"].ToString());

                    studentSheet.Cells[rowFrom, 4].Value = student.firstName;
                    studentSheet.Cells[rowFrom, 5].Value = student.lastName;
                    studentSheet.Cells[rowFrom, 6].Value = row["Semester"].ToString();
                    studentSheet.Cells[rowFrom, 7].Value = row["ClassType"].ToString();
                    studentSheet.Cells[rowFrom, 8].Value = row["ClassNum"].ToString();
                    studentSheet.Cells[rowFrom, 9].Value = row["Tutors"].ToString();
                    studentSheet.Cells[rowFrom, 10].Value = row["TimeStampIn"].ToString();
                    studentSheet.Cells[rowFrom, 11].Value = row["TimeStampOut"].ToString();


                }

                studentSheet.Cells.AutoFitColumns(0);
                SaveSpreadSheetAs(package, "Visits_" + DateTime.Now.GetHashCode(), "Visits");
            }
        }

        public void AllUsersReport()
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet studentSheet = package.Workbook.Worksheets.Add("Users");
                studentSheet.Cells[1, 2].Value = "TableID";
                studentSheet.Cells[1, 3].Value = "StudentID";
                studentSheet.Cells[1, 4].Value = "First Name";
                studentSheet.Cells[1, 5].Value = "Last Name";
                studentSheet.Cells[1, 6].Value = "PasswordHash";
                studentSheet.Cells[1, 7].Value = "UserTime (Min)";
                studentSheet.Cells[1, 8].Value = "DateAdded";


                int rowFrom = 1;
                int rowTo = 1;
                int colStart = 2;
                int colEnd = 8;

                // Set the headers
                using (var range = studentSheet.Cells[rowFrom, colStart, rowTo, colEnd])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.Bold = true;
                }

                // Fill the cells with the database stuffs
                foreach (DataRow row in DConnect.Connection.Users().Rows)
                {
                    using (var range = studentSheet.Cells[++rowFrom, colStart, ++rowTo, colEnd])
                    {
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    studentSheet.Cells[rowFrom, 2].Value = row["id"].ToString();
                    studentSheet.Cells[rowFrom, 3].Value = row["StudentID"].ToString();
                    studentSheet.Cells[rowFrom, 4].Value = row["FirstName"].ToString();
                    studentSheet.Cells[rowFrom, 5].Value = row["LastName"].ToString();
                    studentSheet.Cells[rowFrom, 6].Value = row["PasswordHash"].ToString();
                    studentSheet.Cells[rowFrom, 7].Value = row["UserTime"].ToString();
                    studentSheet.Cells[rowFrom, 8].Value = row["TimeStamp"].ToString();

                }

                studentSheet.Cells.AutoFitColumns(0);
                SaveSpreadSheetAs(package, "Users_" + DateTime.Now.GetHashCode(), "Users");
            }
        }

        public void AllTutorsReport()
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet studentSheet = package.Workbook.Worksheets.Add("Tutors");
                studentSheet.Cells[1, 2].Value = "TableID";
                studentSheet.Cells[1, 3].Value = "StudentID";
                studentSheet.Cells[1, 4].Value = "First Name";
                studentSheet.Cells[1, 5].Value = "Last Name";
                studentSheet.Cells[1, 6].Value = "TutorTime (Min)";
                studentSheet.Cells[1, 7].Value = "DateAdded";


                int rowFrom = 1;
                int rowTo = 1;
                int colStart = 2;
                int colEnd = 7;

                // Set the headers
                using (var range = studentSheet.Cells[rowFrom, colStart, rowTo, colEnd])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    range.Style.Font.Color.SetColor(Color.Black);
                    range.Style.Font.Bold = true;
                }

                // Fill the cells with the database stuffs
                foreach (DataRow row in DConnect.Connection.Tutors().Rows)
                {
                    using (var range = studentSheet.Cells[++rowFrom, colStart, ++rowTo, colEnd])
                    {
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    studentSheet.Cells[rowFrom, 2].Value = row["id"].ToString();
                    studentSheet.Cells[rowFrom, 3].Value = row["StudentID"].ToString();
                    studentSheet.Cells[rowFrom, 4].Value = row["FirstName"].ToString();
                    studentSheet.Cells[rowFrom, 5].Value = row["LastName"].ToString();
                    studentSheet.Cells[rowFrom, 6].Value = row["TutorTime"].ToString();
                    studentSheet.Cells[rowFrom, 7].Value = row["TimeStamp"].ToString();

                }

                studentSheet.Cells.AutoFitColumns(0);
                SaveSpreadSheetAs(package, "Tutors_" + DateTime.Now.GetHashCode(), "Tutors");
            }
        }

        #endregion



        #region Helper
        private void SaveSpreadSheetAs(ExcelPackage package, string fileName, string title)
        {
            package.Workbook.Properties.Company = "Bayleaf";
            package.Workbook.Properties.Title = title;
            package.Workbook.Properties.Author = "Bailey Kocin";
            package.Workbook.Properties.Comments = "Created for Dr. Jason Stone of Cleveland State University's Math Learning Center by Bailey Kocin";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileInfo f = new FileInfo(path + "\\" + fileName + ".xlsx");
            package.SaveAs(f);

        }

        #endregion
    }
}
