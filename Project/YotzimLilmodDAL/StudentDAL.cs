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
    public class StudentDAL : DbContext
    {
        public static void SetStudent() { }
        public static void DeleteStudent(int? id) 
        {
            try
            {
                var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName="_StudentID",Value=id}
            };
                ManageSql.ExecuteScalar("SP_STUDENT_DELETE", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return;
            }catch(Exception ex)
            {
                return;
            }
        }
        public static Student GetStudentsByID(int? studentID)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_StudentID",Value = studentID}
              
            };
            var table = ManageSql.ExecuteSP("SP_GET_STUDENT_BY_ID", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
            return new Student().FillData(table.Rows[0]);
        }

        public static List<Student> GetAllStudents()
        {
            try
            {
                var table = ManageSql.ExecuteSP("SP_GET_ALL_STUDENTS", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", null);
                var students = new List<Student>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    students.Add(new Student().FillData(table.Rows[i]));
                }
                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Student> GetStudentsByTeacherID(int userID)
        {
            try
            {
                //var teacher = TeacherDAL.GetTeacherByUserID(userID);
                var list = new List<MySqlParameter>
            {
                new  MySqlParameter{ParameterName="_TeacherID",Value=userID}
            };
                var table = ManageSql.ExecuteSP("SP_GET_STUDENTS_BY_TEACHER", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
                List<Student> students = new List<Student>();
                foreach (DataRow item in table.Rows)
                {
                    students.Add(new Student(item));
                }
                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static int SetStudent(string name, string lastName, string phoneNumber, string email, string city, string course, string note)
        {
            try
            {
                if (phoneNumber == null)
                    phoneNumber = "";
                if (email == null)
                    email = "";
                if (note == null)
                    note = "";
                var list = new List<MySqlParameter>{
                    new MySqlParameter{ParameterName = "_StudentName",Value = name},
                    new MySqlParameter{ParameterName = "_StudentLastName",Value = lastName},
                    new MySqlParameter{ParameterName = "_StudentPhoneNumber",Value = phoneNumber},
                    new MySqlParameter{ParameterName = "_StudentEmail",Value = email},
                    new MySqlParameter{ParameterName = "_StudentCity",Value = city},
                    new MySqlParameter{ParameterName = "_Course",Value = course},
                    new MySqlParameter{ParameterName = "_Note",Value = note}
                };
                ManageSql.ExecuteScalar("SP_STUDENT_INSERT", "Server=localhost;Database=yotzimlilmod;Uid=root;Pwd=1Qwertyuiop-;", list);
                return 0;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        internal static Student GetStudentByNameEmail(string first, string last, string email)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_StudentName",Value=first},
                new MySqlParameter{ParameterName="_StudentLastName",Value=last},
                new MySqlParameter{ParameterName = "_StudentEmail",Value=email}
            };
            var table = ManageSql.ExecuteSP("SP_GET_STUDENT_BY_NAME_EMAIL", WebConfigurationManager.AppSettings["ConnectionString"], list);
            return new Student().FillData(table.Rows[0]);
        }

        internal static Student GetStudentsByIDNumber(int studentIDNumber)
        {
            var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_StudentIDNumber",Value=studentIDNumber}
    
            };
            var table = ManageSql.ExecuteSP("SP_GET_STUDENT_BY_ID_NUMBER", WebConfigurationManager.AppSettings["ConnectionString"], list);
            return new Student().FillData(table.Rows[0]);
        }

        internal static void UpdateStudentByID(int? id, string first, string last, string email, string phone, string city, int idNumber, string course, string note)
        {
            try
            {
                var list = new List<MySqlParameter>
            {
                new MySqlParameter{ParameterName = "_StudentID",Value=id},
                new MySqlParameter{ParameterName = "_StudentName",Value = first},
                new MySqlParameter{ParameterName = "_StudentLastName",Value=last},
                new MySqlParameter{ParameterName = "_StudentEmail",Value=email},
                new MySqlParameter{ParameterName = "_StudentPhoneNumber",Value=phone},
                new MySqlParameter{ParameterName="_StudentCity",Value = city},
                new MySqlParameter{ParameterName="_StudentIDNumber",Value=idNumber},
                new MySqlParameter{ParameterName="_Course",Value=course},
                new MySqlParameter{ParameterName="_Note",Value=note}
            };

                ManageSql.ExecuteScalar("SP_UPDATE_STUDENT_BY_ID", WebConfigurationManager.AppSettings["ConnectionString"], list);
                return;
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
