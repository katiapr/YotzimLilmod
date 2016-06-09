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
    public class StudentDAL : DbContext
    {
        public static void SetStudent() { }
        public static void DeleteStudent() { }
        public static DataRow GetStudentsByID(int studentID)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_studentID",Value = studentID}
              
            };
            var table = ManageSql.ExecuteSP("SP_TEST_PROCEDURE", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
            return table.Rows[0];
        }

        public static DataTable GetAllStudents()
        {
            return ManageSql.ExecuteSP("SP_GET_ALL_STUDENTS", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", null);

        }
    }
}
