using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Models
{
    public class HoursModels
    {
        public int TeacherID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Total { get; set; }
      
        public string StudentCity { get; set; }
        public string Note { get; set; }

        public string InputStartHours { get; set; }
        public string InputEndHours { get; set; }
        public string InputDate { get; set; }
    }
}
