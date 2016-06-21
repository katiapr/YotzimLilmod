using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
                var table = ManageSql.ExecuteSP("SP_GET_USER", WebConfigurationManager.AppSettings["ConnectionString"], list);
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

        internal static User GetUserByIDNumber(int userIDNumber)
        {
            try
            {
                var list = new List<MySqlParameter>{
                new MySqlParameter{ParameterName = "_UserIDNumber",Value = userIDNumber},
            };
                var table = ManageSql.ExecuteSP("SP_GET_USER_BY_ID_NUMBER", WebConfigurationManager.AppSettings["ConnectionString"], list);

                return new User().FillData(table.Rows[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static User GetUserByNameEmail(string first, string last, string email)
        {
            try{
                var list = new List<MySqlParameter>{
                new MySqlParameter{ParameterName = "_UserFirstName",Value = first},
                new MySqlParameter{ParameterName = "_UserLastName",Value = last},
                new MySqlParameter{ParameterName = "_UserEmail",Value = email}
            };
            var table = ManageSql.ExecuteSP("SP_GET_USER_BY_NAME_EMAIL",WebConfigurationManager.AppSettings["ConnectionString"],list);

            return new User().FillData(table.Rows[0]);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
