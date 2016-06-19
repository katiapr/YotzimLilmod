using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YotzimLilmod.Entities;

namespace YotzimLilmod.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendToCoordinator(Message m)
        {

            return View(m);
        }
    }
}
