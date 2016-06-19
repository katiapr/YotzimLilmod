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
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ChangeUserDetailsPage()
        {
            var user = TeacherDAL.GetTeacherByUserID(Convert.ToInt32(Session["UserID"]));
            UserModels m = new UserModels
            {
                UserName = user.UserName,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserPhoneNumber = user.UserPhoneNumber,
                Password = user.Password,
                userEmail = user.userEmail,
                UserCity = user.UserCity
            };
            return View(m);
        }
        public ActionResult SaveDetails(User u)
        {
            int resp = TeacherDAL.UpdateTeacher(Convert.ToInt32(Session["UserID"]), u.UserName, u.UserFirstName, u.UserLastName, u.userEmail, u.UserCity, u.Password,u.UserPhoneNumber);
            GeneralRequestModels m = new GeneralRequestModels
            {
                code = resp,
                Message = "Updating TeacherDetails"
            };
            return View(m);
        }
        //public ActionResult RegisterTeacher()
        //{

        //    return View();
        //}
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult RegisterTeacher(User u)
        {
            if (u.UserFirstName == null)
                return View();
            string userName = u.userEmail.ToString();
            string password = Guid.NewGuid().ToString().Substring(0, 8);//first password
            int access = 1;//coordinator
            if (u.isScholarship)
                access = 2;
            if (u.isTeacher)
                access = 3;
            int resp = TeacherDAL.SetTeacher(userName, u.UserFirstName.ToString(), u.UserLastName.ToString(), password, u.UserPhoneNumber, u.userEmail.ToString(), u.UserCity.ToString(), access);
            //GeneralRequestModels r = new GeneralRequestModels
            //{
            //    code = resp,
            //    Message = "CreateAccount"
            //};
            if (resp == 0)
            {
                UserModels m = new UserModels()
                {
                    UserName = userName,
                    UserFirstName = u.UserFirstName,
                    UserLastName = u.UserLastName,
                    userEmail = u.userEmail,
                    UserPhoneNumber = u.UserPhoneNumber,
                    UserCity = u.UserCity,
                    UserIDNumber = u.UserIDNumber
                };
                return View("SuccessfulyAdded",m);
            }
            return View();
        }
        public ActionResult RegisterStudent()
        {
            return View();
        }
        public ActionResult CreateStudent()
        {

            return View();
        }
        public ActionResult InsertStudent(Student s)
        {
            int resp = StudentDAL.SetStudent(s.StudentName.ToString(), s.StudentLastName.ToString(), s.StudentPhoneNumber.ToString(),
                s.StudentEmail.ToString(), s.StudentCity.ToString(), s.Course.ToString(), s.Note.ToString());
            if (resp == 0)
            {
                StudentModel m = new StudentModel
                {
                    StudentName = s.StudentName,
                    StudentLastName = s.StudentLastName,
                    studentPhoneNumber = s.StudentPhoneNumber,
                    StudentEmail = s.StudentEmail,
                    StudentCity = s.StudentCity,
                    Course = s.Course,
                    Note = s.Note
                };
                return View(m);
            }
            else return View();

        }
        //public ActionResult SaveDetails()
        //{
        //    return View("SaveDetails");
        //}
        public ActionResult DeleteTeacher()
        {
            return View();
        }
    }
}
