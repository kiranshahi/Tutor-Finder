using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }
        [Required]
        public string FromTime { get; set; }
         [Required]
        public string ToTime { get; set; }
        public int? TutorId { get; set; }
        public string Status { get; set; }
    }
}