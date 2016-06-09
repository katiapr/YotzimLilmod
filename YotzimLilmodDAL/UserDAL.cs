using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YotzimLilmod.Entities;
using YotzimLilmod.MySQL;

namespace YotzimLilmod.YotzimLilmodDAL
{
    public class UserDAL : DbContext
    {
        public static User GetUser(string userName, string password)
        {
            try
            {
                var list = new List<MySqlParameter>
            {
                new MySqlParameter {ParameterName="_userName",Value=userName},
                new MySqlParameter{ParameterName = "_userPassword",Value=password}
            };
                var table = ManageSql.ExecuteSP("SP_GET_USER", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
                if (table.Rows.Count == 1)
                {
                    return new User().FillData(table.Rows[0]);
                }

                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
