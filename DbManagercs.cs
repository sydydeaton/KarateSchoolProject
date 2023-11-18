using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KarateSchoolProject
{
    public class DbManager
    {
        //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sdeat\Source\Repos\KarateSchoolProject\App_Data\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";


        public NetUser getUser(string username)
        {
            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                var user = _db.NetUsers.FirstOrDefault(u => u.UserName == username);
                return user;
            }
        }

        public Member getUserMember(string username)
        {
            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                var user = getUser(username);
                var member = _db.Members.FirstOrDefault(m => m.Member_UserID == user.UserID);
                return member;
            }
        }

        public DataTable GetSectionData(string username, bool isMember)
        {
            DataTable dataTable = new DataTable();

            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                List<SectionModel> sections;
                var user = getUser(username);
                if (isMember)
                {
                    sections = _db.Sections
                    .Where(s => s.Member_ID == user.UserID)
                    .Join(
                        _db.Instructors,
                        section => section.Instructor_ID,
                        instructor => instructor.InstructorID,
                        (section, instructor) => new SectionModel
                        {
                            InstructorName = $"{instructor.InstructorFirstName} {instructor.InstructorLastName}",
                            SectionFee = section.SectionFee,
                            SectionStartDate = section.SectionStartDate,
                            SectionName = section.SectionName,
                        }
                        )
                    .ToList();
                }
                else
                {
                    sections = new List<SectionModel>();
                }
               // else sections =_db.Sections.Where(s => s.Instructor_ID==user.UserID).ToList();

                // Convert the LINQ result to a DataTable.
                dataTable.Columns.Add("SectionName");
                dataTable.Columns.Add("SectionStartDate");
                dataTable.Columns.Add("InstructorName");
                dataTable.Columns.Add("SectionFee");

                foreach (var section in sections)
                {
                    DataRow row = dataTable.NewRow();
                    row["SectionName"] = section.SectionName;
                    row["SectionStartDate"] = section.SectionStartDate;
                    row["InstructorName"] = section.InstructorName;
                    row["SectionFee"] = section.SectionFee;
                    dataTable.Rows.Add(row);
                }

                
            }

            return dataTable;
        }

    }

    public partial class SectionModel
    {
        public string SectionName { get;set; }
        public DateTime SectionStartDate { get;set; }
        public decimal SectionFee { get;set; }
        public string InstructorName { get;set;
        }
    }

}