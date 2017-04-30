using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
       [Compare("Password",ErrorMessage="Password Mismatch")]
        public string RetypePassword { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public int RoleId { get; set; }
    }
}