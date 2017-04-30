using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApplication.Models;

namespace TutorApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        OnlineTutorEntities _db = new OnlineTutorEntities();
        //tutor view in index page
        public ActionResult Index()
        {

            return View(_db.Tutors.ToList());
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}
