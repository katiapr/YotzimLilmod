using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class User : Entity<User>
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public int Access { get; set; }
 
        public User(DataRow data)
        {
            FillData(data);
        }
        public User() { }
        internal User FillData(DataRow data)
        {
            return new User
            {
                UserID = Convert.ToInt32(data["userID"]),
                UserName = Convert.ToString(data["UserName"]),
                Password = Convert.ToString(data["UserPassword"]),
                UserFirstName = Convert.ToString(data["UserFirstName"]),
                UserLastName = Convert.ToString(data["UserLastName"]),
                Email = Convert.ToString(data["UserEmail"]),
                Access = Convert.ToInt32(data["AccessID"])
            };
        }

    }

}
