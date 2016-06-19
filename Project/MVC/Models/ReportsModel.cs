using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Models
{
    public class ReportsModel
    {
        public int TeacherID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Total { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StrudentLastName { get; set; }
        public string StudentCity{get;set;}
        public string Note { get; set; }

    }
}
