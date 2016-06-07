using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Coordinator:Entity<Coordinator>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Coordinator FillData(DataRow row)
        {
            return new Coordinator
            {
                Name = Convert.ToString(row["Name"]),
                PhoneNumber = Convert.ToString(row["PhoneNumber"]),
                IDNumber = Convert.ToString(row["IDNumber"]),
                City = Convert.ToString(row["City"]),
                Address = Convert.ToString(row["Address"])
            };
        }
    }
}
