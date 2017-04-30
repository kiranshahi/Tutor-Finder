﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string EmailId { get; set; }
        [Required]
        public string OldPassword { get; set; }
          [Required]
        
        public string NewPassword { get; set; }
          [Required]
          [Compare("NewPassword", ErrorMessage = "Password Mismatch")]
        public string ConfirmNew { get; set; }
    }
}