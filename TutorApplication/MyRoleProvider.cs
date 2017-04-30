using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TutorApplication.Models;

namespace TutorApplication
{
    public class MyRoleProvider:RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string emailid)
        {
            using (OnlineTutorEntities objContext = new OnlineTutorEntities())
            {
                var objUser = objContext.tblUserInfoes.FirstOrDefault(x => x.EmailId == emailid);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    string[] ret = objUser.UserRoles.Select(x => x.Role.RoleName).ToArray();
                    return ret;
                }
            }	

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string emailid, string roleName)
        {
            var userRoles = GetRolesForUser(emailid);
            return userRoles.Contains(roleName);

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}