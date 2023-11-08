using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarateSchoolProject
{
    public class DbManager
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        private KarateSchoolDBDataContext _db = new KarateSchoolDBDataContext(connectionString);

        public NetUser getUser(string username, string password)
        {
            using (_db)
            {
                var user = _db.NetUsers.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
                return user;
            }
        }

        public Member getUserMember(int userId)
        {
            using (_db)
            {
                var member = _db.Members.FirstOrDefault(m => m.Member_UserID == userId);
                return member;
            }
        }

    }
}