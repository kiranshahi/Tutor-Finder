using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class StudentDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public int CreateStudent(StudentViewModel st)
        {
            Student stu = new Student();
            stu.Name = st.Name;
            stu.DOB = st.DOB;
            stu.Contact = st.Contact;
            stu.Gender = st.Gender;
            stu.EmailId = st.EmailId;
            stu.Address = st.Address;
            _db.Students.Add(stu);
          return  _db.SaveChanges();
        }
        public StudentViewModel GetStudentbyEmailId(string emaild)
        {
            Student st = _db.Students.Where(s => s.EmailId == emaild).FirstOrDefault();
              StudentViewModel stv = new StudentViewModel();
              if (st != null)
              {

                  stv.StudentId = st.StudentId;
                  stv.Name = st.Name;
                  stv.DOB = st.DOB;
                  stv.Contact = st.Contact;
                  stv.Gender = st.Gender;
                  stv.Address = st.Address;
                 
              }
              return stv;

           
        }
        public int UpdateStudent(StudentViewModel st)
        {
            Student stu = _db.Students.Where(s => s.EmailId == st.EmailId).FirstOrDefault();
            stu.Name = st.Name;
            stu.DOB = st.DOB;
            stu.Contact = st.Contact;
            stu.Gender = st.Gender;
        
            stu.Address = st.Address;
           
            return _db.SaveChanges();
        }
    }
}