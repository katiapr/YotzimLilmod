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
        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalHours { get; set; }
        public string Note { get; set; }

        public Hours FillData(DataRow row)
        {
            return new Hours
            {
                HoursID = Convert.ToInt32(row["HoursID"]),
                TeacherID = Convert.ToInt32(row["TeacherID"]),
                StudentID = Convert.ToInt32(row["StudentID"]),
                StartTime = Convert.ToDateTime(row["StartTime"]),
                EndTime = Convert.ToDateTime(row["EndTime"]),
                TotalHours = Convert.ToDecimal(row["TotalHours"]),
                Note = Convert.ToString(row["Note"])
            };
        }
    }
}
