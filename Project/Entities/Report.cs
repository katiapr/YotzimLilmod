using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Report
    {
        public string TeacherName { get; set; }
        public string TecherLastName { get; set; }
        public long IDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string ProgramName { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal Total { get; set; }
        public bool IsDelay { get; set; }
        public bool IsInstruction { get; set; }
        public string Note { get; set; }


        internal Report FillData(DataRow row)
        {
            return new Report
            {
                //Dont forget check Cols Names
                TeacherName = Convert.ToString(row["TeacherName"]),
                TecherLastName = Convert.ToString(row["TeacherLastName"]),
                IDNumber = Convert.ToInt32(row["TeacherIDNumber"]),
                PhoneNumber = Convert.ToString(row["TeacherPhoneNumber"]),
                City = Convert.ToString(row["City"]),
                ProgramName = Convert.ToString(row["ProgramName"]),
                September = Convert.ToDecimal(row["September"]),
                October = Convert.ToDecimal(row["October"]),
                November = Convert.ToDecimal(row["November"]),
                December = Convert.ToDecimal(row["December"]),
                January = Convert.ToDecimal(row["January"]),
                February = Convert.ToDecimal(row["February"]),
                March = Convert.ToDecimal(row["March"]),
                April = Convert.ToDecimal(row["April"]),
                May = Convert.ToDecimal(row["May"]),
                June = Convert.ToDecimal(row["June"]),
                Total = Convert.ToDecimal(row["Total"]),
                IsDelay = Convert.ToBoolean(row["IsDelay"]),
                IsInstruction = Convert.ToBoolean(row["IsInstuction"]),
                Note = Convert.ToString(row["Note"])
            };
        }
    
     }
}
