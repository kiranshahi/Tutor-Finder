//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutorApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Qualification
    {
        public int QualificationId { get; set; }
        public Nullable<int> TutorId { get; set; }
        public string Instution { get; set; }
        public string Board { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CGPA { get; set; }
    }
}
