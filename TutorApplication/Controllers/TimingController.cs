using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApplication.Models;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Controllers
{
    public class TimingController : Controller
    {
        //
        // GET: /Timing/

        ScheduleDB scb = new ScheduleDB();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            ScheduleViewModel scv = new ScheduleViewModel();
            scv.TutorId = Convert.ToInt32(Session["tutorid"].ToString());
            return Json(scb.GetAllScheduleByTeacherId(scv), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ScheduleViewModel sch)
        {
            sch.TutorId = Convert.ToInt32(Session["tutorid"].ToString());
            sch.Status = "Open";
            return Json(scb.InsertSchedule(sch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = scb.GetAllSchedule().Find(x => x.ScheduleId.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ScheduleViewModel sch)
        {
            
            return Json(scb.UpdateSchedule(sch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(scb.DeleteSchedule(ID), JsonRequestBehavior.AllowGet);
        }

    }
}
