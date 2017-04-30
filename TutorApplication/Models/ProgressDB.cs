using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class ProgressDB
    {
        public List<ProgressViewModel> GetAllStudentByTeacherId(int teacherid)
        {
            List<ProgressViewModel> lst = new List<ProgressViewModel>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "SELECT     Student.Name,Tutor.Name AS TeacherName, Student.StudentId, Schedule.FromTime, Schedule.ToTime FROM         Tutor INNER JOIN Schedule ON Tutor.TutorId = Schedule.TutorId INNER JOIN  Hire ON Tutor.TutorId = Hire.Tutorid AND Schedule.ScheduleId = Hire.ScheduleId AND Schedule.ScheduleId = Hire.ScheduleId INNER JOIN Student ON Hire.StudentId = Student.StudentId where Tutor.TutorId=@tutorid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tutorid", teacherid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new ProgressViewModel() {StudentName=(string)dr["Name"],TeacherName=(string)dr["TeacherName"], StudentId=(int)dr["StudentId"],FromTime=(string)dr["FromTime"],ToTime=(string)dr["ToTime"]});

            }
            return lst;
        }
        public ProgressViewModel GetStudentByStudentId(int studentid, int tutorid)
        {
            List<ProgressViewModel> lst = new List<ProgressViewModel>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "SELECT     Student.Name,Tutor.Name AS TeacherName,Tutor.TutorId, Student.StudentId,Schedule.ScheduleId, Schedule.FromTime, Schedule.ToTime FROM         Tutor INNER JOIN Schedule ON Tutor.TutorId = Schedule.TutorId INNER JOIN  Hire ON Tutor.TutorId = Hire.Tutorid AND Schedule.ScheduleId = Hire.ScheduleId AND Schedule.ScheduleId = Hire.ScheduleId INNER JOIN Student ON Hire.StudentId = Student.StudentId where Student.StudentId=@studentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.Parameters.AddWithValue("@tutorid", tutorid);
            SqlDataReader dr = null;
            con.Open();
         

            dr = cmd.ExecuteReader();
            ProgressViewModel pvm=new ProgressViewModel();
            if (dr.Read())
            {
                pvm=new ProgressViewModel() { StudentName = (string)dr["Name"], TeacherId = (int)dr["TutorId"], ScheduleId = (int)dr["ScheduleId"], TeacherName = (string)dr["TeacherName"], StudentId = (int)dr["StudentId"], FromTime = (string)dr["FromTime"], ToTime = (string)dr["ToTime"] };

            }
           return pvm;
        }
        public int AddStudentProgress(ProgressViewModel pvm)
        {
            List<ProgressViewModel> lst = new List<ProgressViewModel>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "insert into Progress values(@a,@b,@c,@d,@e)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", pvm.StudentId);
            cmd.Parameters.AddWithValue("@b", pvm.TeacherId);
            cmd.Parameters.AddWithValue("@c", pvm.ScheduleId);
            cmd.Parameters.AddWithValue("@d", pvm.Comment);
            cmd.Parameters.AddWithValue("@e", pvm.PresentDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<ProgressViewModel> GetListOfTeacherByStudentId(int studentid)
        {
            List<ProgressViewModel> lst = new List<ProgressViewModel>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "SELECT     Student.Name,Tutor.Name AS TeacherName, Tutor.TutorId, Student.StudentId, Schedule.FromTime, Schedule.ToTime FROM         Tutor INNER JOIN  Schedule ON Tutor.TutorId = Schedule.TutorId INNER JOIN  Hire ON Tutor.TutorId = Hire.Tutorid AND Schedule.ScheduleId = Hire.ScheduleId AND Schedule.ScheduleId = Hire.ScheduleId INNER JOIN Student ON Hire.StudentId = Student.StudentId where Student.StudentId=@studentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new ProgressViewModel() { StudentName = (string)dr["Name"], TeacherId=(int)dr["TutorId"], TeacherName = (string)dr["TeacherName"], StudentId = (int)dr["StudentId"], FromTime = (string)dr["FromTime"], ToTime = (string)dr["ToTime"] });

            }
            return lst;
        }
        public List<ProgressViewModel> GetProgressDetailsByTeacherId(int teacherid, int studentid)
        {
            List<ProgressViewModel> lst = new List<ProgressViewModel>();
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=OnlineTutor;");
            string sql = "SELECT     *from Progress where TeacherId=@teacherId and StudentId=@studentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@teacherId", teacherid);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new ProgressViewModel() { Comment=(string)dr["Comment"],PresentDate=(string)dr["PresentDays"]});

            }
            return lst;
        }

    }
}