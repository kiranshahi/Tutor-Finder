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
    
    public partial class Hire
    {
        public Hire()
        {
            this.Payments = new HashSet<Payment>();
        }
    
        public int HireId { get; set; }
        public Nullable<int> Tutorid { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> ScheduleId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> TotalFee { get; set; }
    
        public virtual Schedule Schedule { get; set; }
        public virtual Schedule Schedule1 { get; set; }
        public virtual Student Student { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
