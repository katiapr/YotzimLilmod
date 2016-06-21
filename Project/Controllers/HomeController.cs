using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YotzimLilmod.Entities;
using YotzimLilmod.YotzimLilmodDAL;

namespace YotzimLilmod.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
      
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                var v = UserDAL.GetUser(u.UserName, u.Password);
                if (v != null)
                {
                    Session["UserID"] = v.UserID.ToString();
                    Session["UserPassword"] = v.Password.ToString();
                    Session["UserName"] = v.UserName.ToString();
                    Session["UserFirstName"] = v.UserFirstName.ToString();
                    Session["UserLastName"] = v.UserLastName.ToString();
                    Session["UserEmail"] = v.userEmail.ToString();
                    Session["Access"] = v.Access.ToString();
                    Session["UserPhoneNumber"] = v.UserPhoneNumber.ToString();
                    Session["UserEmail"] = v.userEmail.ToString();
                    Session["UserLastUpdate"] = v.UserLastUpdate.ToString();
                    Session["UserCity"] = v.UserCity.ToString();
                    return RedirectToAction("UserProfile");
                    
                }
                return RedirectToAction("Index");
            }
            return View(u);

        }
        public ActionResult UserProfile()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
