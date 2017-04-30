using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class TutorViewModel
    {
        public int TutorId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(20, ErrorMessage = "Must Be 20 Character")]
        public string Name { get; set; }

      
        [Required(ErrorMessage = "DOB Required")]
        public string DOB { get; set; }
          [Required]
        public string Nationality { get; set; }
          [Required]
        public decimal? HourlyRate { get; set; }

          [Required]
        public string Contact { get; set; }
         
        public string EmailId { get; set; }
         
        
        public string Photo { get; set; }


          [Required]
        public string Address { get; set; }

          [Required]
        public int? SubjectId { get; set; }

       
        public string SubjectName { get; set; }



         [Required]
        public string Instution { get; set; }
          [Required]
        public string Board { get; set; }
          [Required]
        public string StartDate { get; set; }
          [Required]
        public string EndDate { get; set; }
          [Required]
        public string CGPA { get; set; }
    }
}