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
        public ActionResult AddHours(Hours r)
        {
            
            if(ModelState.IsValid)
            {
                var start = Convert.ToDateTime(r.StartTime);
                var end = Convert.ToDateTime(r.EndTime);
                var total = end - start;
                HoursDAL.SetHoursToTeacher(Convert.ToInt32(Session["UserID"]),r.StudentName,r.StudentLastName,r.StartTime,r.EndTime,r.Note);
            }
            return View("Index");
        }
        public ActionResult AllTeachersData()
        {
            return View();
        }
    }
}
