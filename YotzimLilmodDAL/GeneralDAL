using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YotzimLilmod.MySQL;

namespace YotzimLilmod.YotzimLilmodDAL
{
    public class GeneralDAL:DbContext
    {
        public static DataRow Login(string userName, string password)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_userName",Value = userName},
                new MySqlParameter{ParameterName = "_password",Value = password}
            };
            var table = ManageSql.ExecuteSP("SP_TEST_PROCEDURE", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
            return table.Rows[0];
        }
    }
}
