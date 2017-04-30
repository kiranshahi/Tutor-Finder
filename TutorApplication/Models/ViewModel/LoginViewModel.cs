using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class LoginViewModel
    {
        
            [Required]
            public string EmailId { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
           
        

    }
}