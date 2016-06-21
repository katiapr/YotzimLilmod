using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using YotzimLilmod.Entities;
using YotzimLilmod.MySQL;

namespace YotzimLilmod.YotzimLilmodDAL
{
    public class HoursDAL
    {
        public static List<Hours> GetAllHoursOfTeachers()
        {
            try
            {
                var table = ManageSql.ExecuteSP("SP_GET_ALL_HOURS", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", null);
                List<Hours> hoursList = new List<Hours>();
                foreach (DataRow data in table.Rows)
                {
                    hoursList.Add(new Hours(data));
                }
                return hoursList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void SetHoursToTeacher(int teacherID, string studentName,string studentLastName, DateTime start, DateTime end, string note)
        {
            try
            {
                var list = new List<MySqlParameter>
                {
                    new MySqlParameter{ParameterName = "_TeacherID", Value = teacherID},
                    new MySqlParameter{ParameterName = "_StudentName", Value=studentName},
                    new MySqlParameter{ParameterName = "_StudentLastName", Value=studentLastName},
                    new MySqlParameter{ParameterName = "_StartTime",Value=start},
                    new MySqlParameter{ParameterName = "_EndTime",Value=end},
                    new MySqlParameter{ParameterName = "_Note",Value = note},
                        
                };
                ManageSql.ExecuteScalar("SP_HOURS_INSERT", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
            }
            catch (Exception ex)
            {
                return;
            }
        }

    }
}
