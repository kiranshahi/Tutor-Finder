using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TutorApplication.Models;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        UserDB udb = new UserDB();
        RoleDB rdb = new RoleDB();
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public ActionResult Login()
        {
            ViewBag.Roles = rdb.GetAllRoles();
            return View();
        }
        //For Login
        [HttpPost]
        public ActionResult Login(LoginViewModel l,string ReturnUrl = "")
        {
            //ViewBag.Roles = rdb.GetAllRoles();
            bool i = udb.CheckUserLogin(l);
            if (i)
            {
                Session.Add("emailid", l.EmailId);
                FormsAuthentication.SetAuthCookie(l.EmailId,true);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {

                        tblUserInfo tb = _db.tblUserInfoes.Where(u => u.EmailId==l.EmailId && u.Password==l.Password).FirstOrDefault();
                        
                        MyRoleProvider mp = new MyRoleProvider();
                       if( mp.IsUserInRole(l.EmailId,"Teacher")==true)
                       {
                        //if (User.IsInRole("Teacher"))
                        //{
                            return RedirectToAction("Index", "Tutor");
                        }
                        else if(mp.IsUserInRole(l.EmailId,"Student")==true)
                        {
                            return RedirectToAction("index", "Student");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            
            return View();

          
        }
        //for Logout Process
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
        //For Change Password
        [HttpPost]
        public ActionResult ForgetPassword(string Email)
        {
            if (ModelState.IsValid)
            {
                //https://www.google.com/settings/security/lesssecureapps
                //Make Access for less secure apps=true
                //sender email
                //sending email
                string from = "ossrpmail@gmail.com";
                using (MailMessage mail = new MailMessage(from, Email))
                {
                    try
                    {


                        mail.Subject = "Password Recovery";
                        tblUserInfo tb=_db.tblUserInfoes.Where(u=>u.EmailId==Email).FirstOrDefault();

                        mail.Body ="Your Password:"+tb.Password;
                        
                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        //yourpassword
                        NetworkCredential networkCredential = new NetworkCredential(from, "!@#ossrp");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        ViewBag.Message = "Sent";
                    }
                   
                }

            }
            else
            {
                return View();
            }

            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.Roles = rdb.GetAllRoles();
            return View();
        }
        //signup post
        [HttpPost]
        public ActionResult Signup(UserViewModel uv)
        {
            if (ModelState.IsValid)
            {
                udb.CreateUser(uv);
                ViewBag.Message = "User Signup Successfully";
                
            }
            return Content("User Signuped Successfully", "text/html");
           
        
           
        }
      

    }
}
