using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using YotzimLilmod.YotzimLilmodDAL;

namespace YotzimLilmod.Entities
{
    public class Teacher : Entity<Teacher>
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }

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
                TeacherID = Convert.ToInt32(row["UserID"]),
                TeacherName = Convert.ToString(row["UserName"]),
                TeacherLastName = Convert.ToString(row["UserLastName"])
            };
        }
    }
}
