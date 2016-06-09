using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Teacher : Entity<Teacher>
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        public Teacher(DataRow row)
        {
            FillData(row);
        }

        public Teacher()
        {

        }
        internal Teacher FillData(DataRow row)
        {
            return new Teacher
            {
                TeacherID = Convert.ToInt32(row["TeacherID"]),
                TeacherName = Convert.ToString(row["TeacherName"])
            };
        }
    }
}
