using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YotzimLilmod.Entities;

namespace YotzimLilmod.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string studentPhoneNumber { get; set; }
        public string StudentEmail { get; set; }
        public string StudentCity { get; set; }
        public string Course { get; set; }
        public string Note { get; set; }
       
    }


}
