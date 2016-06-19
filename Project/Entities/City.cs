using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

        public City() { }
        public City(DataRow row)
        {
            FillData(row);
        }

        internal City FillData(DataRow data)
        {
            return new City
            {
                CityID = Convert.ToInt32(data["CityID"]),
                CityName = Convert.ToString(data["CityName"])
            };
        }
    }
}
