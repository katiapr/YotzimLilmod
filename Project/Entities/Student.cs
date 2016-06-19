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
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentCity { get; set; }
        public string Course { get; set; }
        public string Note { get; set; }
        public int TeacherID { get; set; }
        public int StudentIDNumber { get; set; }


        public Student(DataRow data)
        {
            FillData(data);
        }

        public Student() { }
        internal  Student FillData(DataRow row)
        {
            return new Student()
            {
                StudentID = Convert.ToInt32(row["StudentID"]),
                StudentName = Convert.ToString(row["StudentName"]),
                StudentLastName = Convert.ToString(row["StudentLastName"]),
                StudentEmail = Convert.ToString(row["StudentEmail"]),
                StudentPhoneNumber = Convert.ToString(row["StudentPhoneNumber"]),
                StudentCity = Convert.ToString(row["StudentCity"]),
                Course = Convert.ToString(row["Course"]),
                Note = Convert.ToString(row["Note"]),
                TeacherID = Convert.ToInt32(row["TeacherID"]),
                StudentIDNumber = Convert.ToInt32(row["StudentIDNumber"])
            };
        }
    }

}
