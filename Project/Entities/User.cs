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
        public string userEmail { get; set; }
        public int Access { get; set; }
        public string UserCity { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool isTeacher { get; set; }
        public bool isCoordinator { get; set; }
        public bool isScholarship { get; set; }
        public int UserIDNumber { get; set; }
        public DateTime UserLastUpdate { get; set; }
        //public User(DataRow data)
        //{
        //    FillData(data);
        //}
        //public User() { }
        internal User FillData(DataRow data)
        {
            return new User()
            {
                UserID = Convert.ToInt32(data["UserID"]),
                UserName = Convert.ToString(data["UserName"]),
                Password = Convert.ToString(data["UserPassword"]),
                UserFirstName = Convert.ToString(data["UserFirstName"]),
                UserLastName = Convert.ToString(data["UserLastName"]),
                userEmail = Convert.ToString(data["UserEmail"]),
                Access = Convert.ToInt32(data["Access"]),
                UserCity = Convert.ToString(data["UserCity"]),
                UserPhoneNumber = Convert.ToString(data["UserPhoneNumber"]),
                UserIDNumber = Convert.ToInt32(data["UserIDNumber"]),
                UserLastUpdate = data["UserLastUpdate"] != null ? Convert.ToDateTime(data["UserLastUpdate"]) : default(DateTime)
            };
        }

    }

}
