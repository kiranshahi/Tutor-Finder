using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(20, ErrorMessage = "Must Be 20 Character")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "DOB Required")]
        public DateTime? DOB { get; set; }
     

        [Required]
        public string Contact { get; set; }
        public string Gender { get; set; }
       
        public string EmailId { get; set; }
         [Required]
        public string Address { get; set; }
    }
}