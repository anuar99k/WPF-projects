using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Module_03__tests_app_
{
    class DBcontext
    {
        public static User currentUser { get; set; }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(@"localDb.db"))
            {
                users = db.GetCollection<User>("user").FindAll().ToList();
            }
            return users;
        }

        public bool AddUser(User user)
        {
            using (var db = new LiteDatabase(@"localDb.db"))
            {
                var users = db.GetCollection<User>("user");

                users.Insert(user);
                return true;
            }
        }

        public bool AddUser(string login, string password)
        {
            User user = new User() { Login = login, Password = password };

            using(var db = new LiteDatabase(@"localDb.db"))
            {
                var users = db.GetCollection<User>("user");

                users.Insert(user);
                return true;
            }
        }
    }
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
