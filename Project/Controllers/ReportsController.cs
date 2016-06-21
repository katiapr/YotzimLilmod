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
    public class ReportsController : Controller
    {
        // GET: Hours
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HoursReport()
        {
            List<Hours> hoursTable = HoursDAL.GetAllHoursOfTeachers();
            if (hoursTable != null)
            {
                foreach (Hours item in hoursTable)
                {
                    return View(new ReportsModel
                    {
                        End = item.EndTime,
                        Start = item.StartTime,
                        Total = item.TotalHours
                    });
                }
            }
            return View();
        }
        //Add cshtml page for successing
        //public ActionResult AddHours(Hours r)
        //{

        //    if(ModelState.IsValid)
        //    {
        //        var start = Convert.ToDateTime(r.StartTime);
        //        var end = Convert.ToDateTime(r.EndTime);
        //        var total = end - start;
        //        HoursDAL.SetHoursToTeacher(Convert.ToInt32(Session["UserID"]),r.StudentName,r.StudentLastName,r.StartTime,r.EndTime,r.Note);
        //    }
        //    return View("Index");
        //}
        public ActionResult AllTeachersData()
        {
            return View();
        }
        public ActionResult AddHours()
        {
            return View();
        }
        public ActionResult UpdateHours(Hours h)
        {
            //var user = TeacherDAL.GetTeacherByUserID(Convert.ToInt32(Session["UserID"]));
            string startTime = h.InputDate + " " + h.InputStartHours;
            DateTime start = new DateTime();
            start = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", null);

            string endTime = h.InputDate + " " + h.InputEndHours;
            DateTime end = new DateTime();
            end = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm", null);


            TimeSpan temp = end.Subtract(start);
            decimal totalHours = temp.Hours;//= Convert.ToDecimal();
            decimal totalMinutes = temp.Minutes;
            string totalString;
            if (totalHours != 0)
            {
                totalString = Convert.ToString(totalHours) + "." + Convert.ToString(totalMinutes - totalHours * 60);
            }
            else totalString = "0." + Convert.ToString(totalMinutes);

            bool isEmptyRow = TeacherDAL.UpdateTeacherHours(Convert.ToInt32(Session["UserID"]), start, end, Convert.ToDecimal(totalString), h.Note);
            //TeacherDAL.UpdateTeacherReport()
            var list = TeacherDAL.GetHoursByTeacher(Convert.ToInt32(Session["UserID"]));
            HoursListModels m = new HoursListModels
            {
                TeacherHoursList = list
            };
            return View("ShowTeacherHoursList", m);
        }
        public ActionResult ShowTeacherHoursList()
        {
            var list = TeacherDAL.GetHoursByTeacher(Convert.ToInt32(Session["UserID"]));
            HoursListModels m = new HoursListModels
            {
                TeacherHoursList = list
            };
            return View("ShowTeacherHoursList", m);
        }
        public ActionResult DeleteHours(int? id)
        {
            TeacherDAL.RemoveHouresByID(id);

            var list = TeacherDAL.GetHoursByTeacher(Convert.ToInt32(Session["UserID"]));
            HoursListModels m = new HoursListModels
            {
                TeacherHoursList = list
            };
            return View("ShowTeacherHoursList", m);
        }
    }
}
