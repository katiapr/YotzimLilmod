using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using YotzimLilmod.Entities;
using YotzimLilmod.MySQL;

namespace YotzimLilmod.YotzimLilmodDAL
{
    public class GeneralDAL:DbContext
    {
        public static DataRow Login(string userName, string password)
        {
            //"Server=localhost;Database=;Uid=root;Pwd=1Qwertyuiop-;"
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_userName",Value = userName},
                new MySqlParameter{ParameterName = "_password",Value = password}
            };
            var table = ManageSql.ExecuteSP("SP_TEST_PROCEDURE", WebConfigurationManager.AppSettings["ConnectionString"], list);
            return table.Rows[0];
        }
        public  static List<City> GetAllCities()
        {
            var table = ManageSql.ExecuteSP("SP_GET_ALL_CITIES", WebConfigurationManager.AppSettings["ConnectionString"], null);
            List<City> list = new List<City>();
            foreach(DataRow item in table.Rows)
            {
                list.Add(new City(item));
            }
            return list;
        }
    }
    
}
