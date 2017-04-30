using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class PaymentDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public int CreatePayment(PaymentViewModel payvm)
        {
            Payment pay=new Payment();
            pay.PaymentDate=payvm.PaymentDate;
            pay.Status=payvm.Status;
            pay.HireId=payvm.HireId;
            _db.Payments.Add(pay);
          return  _db.SaveChanges();
        }
        public List<PaymentModified> GetAllPaymentByStudentid(int studentid)
        {
            List<PaymentModified> lstpay = new List<PaymentModified>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "SELECT     Tutor.Name,Hire.StudentId, Hire.StartDate, Hire.EndDate, Hire.TotalFee, Payment.Status, Payment.PaymentDate FROM         Hire INNER JOIN  Payment ON Hire.HireId = Payment.HireId INNER JOIN Tutor ON Hire.Tutorid = Tutor.TutorId where Hire.StudentId=@studentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lstpay.Add(new PaymentModified(){StudetId=(int)dr["StudentId"],TutorName=(string)dr["Name"],StartDate=(DateTime)dr["StartDate"],EndDate=(DateTime)dr["EndDate"], TotalFee=(decimal)dr["TotalFee"],Status=(bool)dr["Status"],PaymentDate=(DateTime)dr["PaymentDate"]});

            }
            return lstpay;
            
        }
        public class PaymentModified
        {
            public int StudetId { get; set; }
            public string TutorName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal TotalFee { get; set; }
            public bool Status { get; set; }
            public DateTime PaymentDate { get; set; }

        }
    }
}