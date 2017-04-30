using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class UserDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public int CreateUser(UserViewModel uv)
        {

            UserRole ur = new UserRole();
            tblUserInfo tb = new tblUserInfo();
            tb.EmailId = uv.EmailId;
            tb.Password = uv.Password;
            tb.Firstname = uv.Firstname;
            tb.Lastname =uv.Lastname;
            _db.tblUserInfoes.Add(tb);

             _db.SaveChanges();

             ur.RoleId = uv.RoleId;
             ur.UserId = tb.UserId;
             _db.UserRoles.Add(ur);
            return _db.SaveChanges();
        }
        public int UpdatePassword(ChangePasswordViewModel uv)
        {
           
            tblUserInfo tb = _db.tblUserInfoes.Where(u=>u.EmailId==uv.EmailId).FirstOrDefault();
          
            tb.Password = uv.NewPassword;
           
        
            return _db.SaveChanges();
        }
        public bool checkUser(ChangePasswordViewModel uv)
        {
            tblUserInfo tb = _db.tblUserInfoes.Where(u => u.EmailId == uv.EmailId && u.Password == uv.OldPassword).FirstOrDefault();
            if(tb!=null)
            {
                return true;
            }
            else{
                return false;
            }
        }
        public bool CheckUserLogin(LoginViewModel lg)
        {
            var users = _db.tblUserInfoes.Where(u => u.EmailId == lg.EmailId && u.Password == lg.Password).FirstOrDefault();
            if (users != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}