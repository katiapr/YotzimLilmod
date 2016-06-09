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
    public class TeacherDAL : DbContext
    {
        public static DataTable GetAllTeachers()
        {
            return ManageSql.ExecuteSP("SP_GET_ALL_TEACHERS", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", null);

        }
        public static List<Teacher> GetHoursByTeacher()
        {
            return null;
        }
        public static void SetTeacher() { }
        public static void DeleteTeacher() { }
        public static void UpdateTeacherHours() { }

    }
}
