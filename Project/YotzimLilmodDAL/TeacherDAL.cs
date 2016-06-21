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
    public class TeacherDAL : DbContext
    {
        public static List<User> GetAllTeachers()
        {
            var table = ManageSql.ExecuteSP("SP_GET_ALL_TEACHERS", WebConfigurationManager.AppSettings["ConnectionString"], null);
            List<User> teacherList = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                //Console.WriteLine(row.ItemArray.ToString());
                teacherList.Add(new User().FillData(row));
            }
            return teacherList;
        }
        public static List<Teacher> GetHoursByTeacher()
        {
            return null;
        }
        public static void SetTeacher() { }
        public static void DeleteTeacher(int? idUser)
        {
            try
            {
                var list = new List<MySqlParameter>{
                new MySqlParameter{ParameterName="_UserID",Value=idUser}
            };
                ManageSql.ExecuteScalar("SP_TEACHER_DELETE", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return;
            }
            catch (Exception ex)
            {
                return;
            }

        }
        public static void UpdateTeacherHours() { }


        public static User GetTeacherByUserID(int userID)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName="_userID",Value=userID}
            };
            var table = ManageSql.ExecuteSP("SP_GET_USER_BY_USER_ID", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
            return new User().FillData(table.Rows[0]);
        }



        //internal static void UpdateTeacher(int p)
        //{

        //}


        internal static int UpdateTeacher(int userID, string userName, string userFirstName, string userLastName, string userEmail, string userCity, string userPassword, string userPhoneNumber)
        {
            try
            {
                var list = new List<MySqlParameter>
                {
                    new MySqlParameter{ParameterName = "_userID",Value=userID},
                    new MySqlParameter{ParameterName = "_userName",Value=userName},
                    new MySqlParameter{ParameterName = "_userFirstName",Value=userFirstName},
                    new MySqlParameter{ParameterName = "_userLastName",Value=userLastName},
                    new MySqlParameter{ParameterName = "_userEmail",Value=userEmail},
                    new MySqlParameter{ParameterName = "_userCity",Value=userCity},
                    new MySqlParameter{ParameterName = "_userPassword",Value=userPassword},
                    new MySqlParameter{ParameterName = "_UserPhoneNumber",Value=userPhoneNumber},
                };

                ManageSql.ExecuteSP("SP_UPDATE_TEACHER", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return 0;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        //TeacherDAL.SetTeacher(userName, u.UserFirstName.ToString(), u.UserLastName.ToString(), password, u.UserPhoneNumber, u.userEmail.ToString(), u.UserCity.ToString(), access);

        internal static int SetTeacher(string userName, string firstName, string lastName, string password, string phoneNumber, string email, string city, int access,int userIDNumber)
        {
            try
            {
                var list = new List<MySqlParameter>
                {
                    new MySqlParameter{ParameterName = "_userName",Value=userName},
                    new MySqlParameter{ParameterName = "_userFirstName",Value=firstName},
                    new MySqlParameter{ParameterName = "_userLastName",Value=lastName},
                    new MySqlParameter{ParameterName = "_UserPhoneNumber",Value=phoneNumber},
                    new MySqlParameter{ParameterName = "_userEmail",Value=email},
                    new MySqlParameter{ParameterName = "_userCity",Value=city},
                    new MySqlParameter{ParameterName = "_Access",Value = access},
                    new MySqlParameter{ParameterName = "_userPassword",Value=password},
                    new MySqlParameter{ParameterName = "_CourseID",Value = 0},
                    new MySqlParameter{ParameterName="_UserIDNumber",Value=userIDNumber}
                };

                ManageSql.ExecuteScalar("SP_TEACHER_INSERT", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return 0;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        internal static void UpdateTeacherDetails(int? id, int idNumber, string name, string first, string last, string phone, string email, string city)
        {
            try
            {
                var list = new List<MySqlParameter>{
               new MySqlParameter{ParameterName="_UserID",Value=id},
               new MySqlParameter{ParameterName = "_UserName",Value=name},
               new MySqlParameter{ParameterName="_UserIDNumber",Value=idNumber},
               new MySqlParameter{ParameterName="_UserFirstName",Value=first},
               new MySqlParameter{ParameterName="_UserLastName",Value=last},
               new MySqlParameter{ParameterName="_UserPhoneNumber",Value=phone},
               new MySqlParameter{ParameterName="_UserEmail",Value=email},
               new MySqlParameter{ParameterName="_UserCity",Value=city}
           };
                ManageSql.ExecuteScalar("SP_TEACHER_UPDATE", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal static bool UpdateTeacherHours(int userID, DateTime start, DateTime end, decimal total,string note)
        {
            var list = new List<MySqlParameter>{
                new MySqlParameter{ParameterName="_UserID",Value=userID},
                new MySqlParameter{ParameterName="_StartTime",Value=start},
                new MySqlParameter{ParameterName="_EndTime",Value = end},
                new MySqlParameter{ParameterName="_TotalHours",Value=total},
                new MySqlParameter{ParameterName="_Note",Value=note}
            };
           var table = ManageSql.ExecuteSP("SP_HOURS_INSERT", WebConfigurationManager.AppSettings["ConnectionString"], list);
            if(table == null)
            {
                return true;
            }
            return false;
            
        }

        internal static List<Hours> GetHoursByTeacher(int userID)
        {
            var list = new List<MySqlParameter>{
                new MySqlParameter{ParameterName="_TeacherID",Value=userID}
           };
            var table = ManageSql.ExecuteSP("SP_GET_ALL_HOURS_BY_TEACHER", WebConfigurationManager.AppSettings["ConnectionString"], list);
            List<Hours> hoursList = new List<Hours>();
            foreach (DataRow row in table.Rows)
            {
                //Console.WriteLine(row.ItemArray.ToString());
                hoursList.Add(new Hours().FillData(row));
            }
            return hoursList;
        }

        internal static void RemoveHouresByID(int? id)
        {
            var list = new List<MySqlParameter>{
               new MySqlParameter{ParameterName="_id",Value=id}
           };
           ManageSql.ExecuteScalar("SP_DELETE_TEACHER_HOURES_BY_ID", WebConfigurationManager.AppSettings["ConnectionString"], list);
            
        }
    }
}
