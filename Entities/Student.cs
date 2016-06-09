using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Student : Entity<Student>
    {
        public int StudentID { get; set; }
        public string StrudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentCity { get; set; }
        public string Course { get; set; }
        public string Note { get; set; }

        public static Student FillData(DataRow row)
        {
            return new Student()
            {
                StudentID = Convert.ToInt32(row["StudentID"]),
                StrudentName = Convert.ToString(row["StrudentName"]),
                StudentEmail = Convert.ToString(row["StudentEmail"]),
                StudentPhoneNumber = Convert.ToString(row["StudentPhoneNumber"]),
                StudentCity = Convert.ToString(row["StudentCity"]),
                Course = Convert.ToString(row["Course"]),
                Note = Convert.ToString(row["Note"])
            };
        }
    }

}
