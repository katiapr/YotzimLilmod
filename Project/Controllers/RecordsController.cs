using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YotzimLilmod.Entities;
using YotzimLilmod.Models;
using YotzimLilmod.YotzimLilmodDAL;

namespace YotzimLilmod.Controllers
{
    public class RecordsController : Controller
    {
        // GET: Records
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowTeacherRecords()
        {
            List<User> teacherList = TeacherDAL.GetAllTeachers();

            TeacherListModels m = new TeacherListModels
            {
                TeacherList = teacherList,
            };
            return View(m);
        }
        public ActionResult ChangeDataDetailesTeachers()
        {
            var user = TeacherDAL.GetTeacherByUserID(Convert.ToInt32(1));
            UserModels m = new UserModels
            {
                UserName = user.UserName,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserCity = user.UserCity,
                userEmail = user.userEmail,
                Password = user.Password,
                UserPhoneNumber = user.UserPhoneNumber

            };
            return View(m);
        }
        public ActionResult ShowStudentsRecords()
        {

            List<Student> studentsList = StudentDAL.GetAllStudents();
            StudentsListModels m = new StudentsListModels
            {
                StudentsList = studentsList
            };
            return View(m);
        }
       
        public ActionResult ChangeDataDetailesStudent(int? k)
        {
            return RedirectToAction("ShowStudentsRecords");
        }
        public ActionResult DeleteStudent(string k)
        {
            return RedirectToAction("ShowStudentsRecords");
        }
        public ActionResult SearchUserPage()
        {
            return View();
        }
        public ActionResult SearchUser(User u)
        {
           
            User user = null;
            if (u.UserIDNumber == 0)
            {
                 user = UserDAL.GetUserByNameEmail(u.UserFirstName, u.UserLastName, u.userEmail);
            }
            else
            {
                user = UserDAL.GetUserByIDNumber(u.UserIDNumber);
            }
            if(user == null)
            {
                return View("UserProfile","Home");
            }
            UserModels m  = new UserModels
            {
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                userEmail = user.userEmail,
                UserPhoneNumber = user.UserPhoneNumber,
                UserCity = user.UserCity,
                UserLastUpdate = user.UserLastUpdate
            };
            return View(m);
        }
        public ActionResult SearchStudentPage()
        {
            return View();
        }
        public ActionResult SearchStudent(Student s)
        {
            Student student = null;
            if (s.StudentIDNumber == 0)
            {
                student = StudentDAL.GetStudentByNameEmail(s.StudentName, s.StudentLastName, s.StudentEmail);
            }
            else student = StudentDAL.GetStudentsByIDNumber(s.StudentIDNumber);

            if (student == null)
            {
                return View("UserProfile", "Home");
            }
            StudentModel m = new StudentModel
            {
                StudentName = student.StudentName,
                StudentLastName = student.StudentLastName,
                studentPhoneNumber = student.StudentPhoneNumber,
                StudentEmail = student.StudentEmail,
                StudentIDNumber = student.StudentIDNumber,
                StudentCity = student.StudentCity
            };
            return View(m);
        }
    }
}
