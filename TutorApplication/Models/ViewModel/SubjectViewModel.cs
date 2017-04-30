using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
    }
}