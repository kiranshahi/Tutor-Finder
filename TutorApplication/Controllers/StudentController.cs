using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApplication.Models;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        //class object
        PaymentDB pdb = new PaymentDB();
        UserDB udb = new UserDB();
        StudentDB stb = new StudentDB();
        TutorDB tdb = new TutorDB();
        ScheduleDB sdb = new ScheduleDB();
        HireDB hrdb = new HireDB();
        ProgressDB prdb = new ProgressDB();



        [Authorize(Roles = "Student")]

        
        public ActionResult Index()
        {
            StudentViewModel st = stb.GetStudentbyEmailId(Session["emailid"].ToString());
            Session.Add("studentid", st.StudentId);
            if (st.StudentId > 0)
            {
                ViewBag.SaveText = "Update";
                Session.Add("action", "Update");

            }
            else
            {
                ViewBag.SaveText = "Save";
                Session.Add("action", "Save");
            }
            return View(st);


        }
        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult Index(StudentViewModel st)
        {
            if (Session["action"].ToString() == "Save")
            {
                st.EmailId = Session["emailid"].ToString();
                if (ModelState.IsValid)
                {
                    int i = stb.CreateStudent(st);
                    if (i > 0)
                    {
                        ViewBag.SaveText = "Update";
                        st.Name = "";
                        st.DOB = null;
                        st.Contact = "";
                        st.Gender = "Male";
                        st.Address = "";
                    }
                }
                return Content("Student Created Successfully", "text/html");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    st.EmailId = Session["emailid"].ToString();
                    int i = stb.UpdateStudent(st);
                    st.Name = "";
                    st.DOB = null;
                    st.Contact = "";
                    st.Gender = "Male";
                    st.Address = "";
                }
                return Content("Student updated Successfully", "text/html");
            }
        }
        [Authorize(Roles = "Student")]
        public ActionResult ViewTutor()
        {

            return View(tdb.GetAllTutor());
        }
        [Authorize(Roles = "Student")]
        public ActionResult ViewSchedule(int id)
        {
            Session.Add("teacherid", id.ToString());
            return View(sdb.GetAllScheduleByTeacherid(id));
        }
        public ActionResult BookNow(int id)
        {
            Session.Add("scheduleid", id.ToString());

            HireViewModel hrv = new HireViewModel();
            DateTime todaydate = DateTime.Today;

            hrv.StartDate = todaydate;

            DateTime enddate = DateTime.Today.AddDays(30);
            hrv.EndDate = DateTime.Today.AddMonths(1);

            TutorViewModel tvm = tdb.GetTutorbyTutorId(Convert.ToInt32(Session["teacherid"].ToString()));
            decimal? rateperhour = tvm.HourlyRate;


            hrv.TotalFee = rateperhour * 30;


            return View(hrv);

        }
        [HttpPost]
        public ActionResult BookNow(HireViewModel hrv)
        {
           // Session.Add("hireid", Request.QueryString["id"].ToString());
            hrv.ScheduleId = Convert.ToInt32(Session["scheduleid"].ToString());
            hrv.Tutorid = Convert.ToInt32(Session["teacherid"].ToString());
            hrv.StudentId = Convert.ToInt32(Session["studentid"].ToString());
                hrdb.InsertHire(hrv);
                ScheduleViewModel svm=new ScheduleViewModel();
                svm.ScheduleId=Convert.ToInt32(Session["scheduleid"].ToString());
                svm.Status="Closed";
                sdb.UpdateScheduleStatus(svm);
            
            ViewBag.Message = "Teacher Booked Successfully";
            return View();
        }
        public ActionResult GetHiredByStudentId()
        {
            List<Hire> lsthire = hrdb.GetHiredByStudentId(Convert.ToInt32(Session["studentid"].ToString()));
            return View(lsthire);
        }
        //[HttpPost]
        //   public void CalcualtePrice(FormCollection fc)
        //   {
        //       DateTime date1 =Convert.ToDateTime(fc["StartDate"]);
        //       DateTime date2 =Convert.ToDateTime(fc["EndDate"]);
        //       TimeSpan ts = date2.Subtract(date1);
        //       int days = ts.Days;
        //       fc["TotalFee"] = days.ToString();
        //       ViewBag.Days = days;
        //       //return View();

        //   }
        public ActionResult UpdateInfo()
        {
            return View();
        }
        public ActionResult BookTeacher()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            if (ModelState.IsValid)
            {
                ch.EmailId = Session["emailid"].ToString();

                if (udb.checkUser(ch))
                {
                    int i = udb.UpdatePassword(ch);
                    if (i > 0)
                    {
                        ViewBag.Message = "Password Changed";
                    }
                }
            }
            return View();
        }
        public ActionResult BookTutor()
        {
            return View();
        }
        public ActionResult Payment(int id)
        {
         Hire hr=   hrdb.GetDetailsByHireId(id);
         Session.Add("hireid", id.ToString());
         PaymentViewModel payvm = new PaymentViewModel();
         payvm.Amount = hr.TotalFee;

            return View(payvm);
        }
        [HttpPost]
        public ActionResult Payment(PaymentViewModel payvm)
        {
            payvm.Status = true;
            payvm.HireId = Convert.ToInt32(Session["hireid"].ToString());
           
            int i = pdb.CreatePayment(payvm);
            ViewBag.Message = "Payment Done";
            return View();
        }
        public ActionResult ViewPayment()
        {
          var p=  pdb.GetAllPaymentByStudentid(Convert.ToInt32(Session["studentid"].ToString()));
          return View(p);
        }
        public JsonResult GetAmount(DateTime starDate, DateTime endDate)
        {
            //HireViewModel hr = new HireViewModel();
            //DateTime? startd = hr.StartDate;
            //DateTime? endd = hr.EndDate;

            DateTime fromdate = starDate;
            DateTime todate = endDate;
            TimeSpan ts = todate.Subtract(fromdate);
            var a = ts.Days;
            TutorViewModel tvm = tdb.GetTutorbyTutorId(Convert.ToInt32(Session["teacherid"].ToString()));
            decimal? rateperhour = tvm.HourlyRate;




            decimal? totalamt = a * rateperhour;
            //HireViewModel hrv = new HireViewModel();
            //hrv.TotalFee = totalamt;
         
            return Json(totalamt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTeacherAssignProgress()
        {
            List<ProgressViewModel> lstpvm = prdb.GetListOfTeacherByStudentId(Convert.ToInt32(Session["studentid"].ToString()));
            return View(lstpvm);
        }
        public ActionResult ProgressDetailGivenByTeacher(int id)
        {
            List<ProgressViewModel> lstpvm = prdb.GetProgressDetailsByTeacherId(id, Convert.ToInt32(Session["studentid"].ToString()));
            return View(lstpvm);
        }


    }
}
