using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Hours:Entity<Hours>
    {
        public int HoursID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalHours { get; set; }
        public string Note { get; set; }

        public string InputStartHours { get; set; }
        public string InputEndHours { get; set; }
        public string InputDate { get; set; }

        public Hours(DataRow row)
        {
            FillData(row); 
        }
        public Hours() { }

        public Hours FillData(DataRow row)
        {
            return new Hours
            {
                HoursID = Convert.ToInt32(row["id"]),
                //TeacherName = Convert.ToString(row["TeacherName"]),
                //TeacherLastName = Convert.ToString(row["TeacherLastName"]),
                //StudentName = Convert.ToString(row["StudentID"]),
                //StudentLastName = Convert.ToString(row["StrudentLastName"]),
                StartTime = Convert.ToDateTime(row["StartTime"]),
                EndTime = Convert.ToDateTime(row["EndTime"]),
                TotalHours = Convert.ToDecimal(row["TotalHours"]),
                Note = Convert.ToString(row["Note"])
            };
        }
    }
}
