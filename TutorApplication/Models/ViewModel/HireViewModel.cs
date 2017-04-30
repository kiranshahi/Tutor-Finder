using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class HireViewModel
    {
        public int HireId { get; set; }
        public int? Tutorid { get; set; }
        public int? StudentId { get; set; }
        public int? ScheduleId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime? StartDate { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime? EndDate { get; set; }
        public decimal? TotalFee { get; set; }

       
    }
}