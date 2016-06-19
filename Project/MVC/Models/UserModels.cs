using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;


namespace YotzimLilmod.Models
{
    public class UserModels
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCity { get; set; }
        public string userEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool isTeacher { get; set; }
        public bool isCoordinator { get; set; }
        public bool isScholarship { get; set; }
        public int UserIDNumber { get; set; }
        public DateTime UserLastUpdate { get; set; }

        public UserModels()
        {

        }
        
    }
}
