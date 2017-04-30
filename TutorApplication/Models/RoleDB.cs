using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class RoleDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public int CreateRole(RoleViewModel rv)
        {
            Role r = new Role();
            r.RoleName = rv.RoleName;
            _db.Roles.Add(r);
            return _db.SaveChanges();
        }
        public List<RoleViewModel> GetAllRoles()
        {
            List<RoleViewModel> lstrv = new List<RoleViewModel>();
            var rs = _db.Roles.ToList();
            foreach (var item in rs)
            {
                lstrv.Add(new RoleViewModel() { RoleId = item.RoleId, RoleName = item.RoleName });
            }
            return lstrv;
        }
    }
}