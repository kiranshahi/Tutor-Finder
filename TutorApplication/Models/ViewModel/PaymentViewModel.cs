using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class PaymentViewModel
    {
        public int? HireId { get; set; }
        public bool? Status { get; set; }
        [Required]
        public decimal?  Amount { get; set; }
         [Required]
        public DateTime? PaymentDate { get; set; }
         [Required]
        public string BankVoucherNo { get; set; }
    }
}