using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class TutorDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public List<TutorViewModel> GetAllTutor()
        {
            List<TutorViewModel> lsttut = new List<TutorViewModel>();
            var tuts = _db.Tutors.Include("Subject").ToList();
            foreach (var item in tuts)
            {
                lsttut.Add(new TutorViewModel() {TutorId=item.TutorId, Name = item.Name, Nationality = item.Nationality, HourlyRate = item.HourlyRate, Contact = item.Contact,Address=item.Address, SubjectName = item.Subject.SubjectName });

            }
            return lsttut;
        }
       
        public int CreateTutor(TutorViewModel tvm)
        {
            Tutor tu = new Tutor();
            tu.Name = tvm.Name;
            tu.DOB = tvm.DOB;
            tu.Nationality = tvm.Nationality;
            tu.HourlyRate = tvm.HourlyRate;
            tu.Contact = tvm.Contact;
            tu.EmailId = tvm.EmailId;
            tu.Photo = tvm.Photo;
            tu.Address = tvm.Address;
            tu.SubjectId = tvm.SubjectId;
         
            _db.Tutors.Add(tu);
            _db.SaveChanges();

            Qualification qf = new Qualification();
            qf.TutorId = tu.TutorId;
            qf.Instution = tvm.Instution;
            qf.Board = tvm.Board;
            qf.StartDate = tvm.StartDate;
            qf.EndDate = tvm.EndDate;
            qf.CGPA = tvm.CGPA;
            _db.Qualifications.Add(qf);
           return  _db.SaveChanges();
        }
        public int UpdateTutor(TutorViewModel tvm)
        {
            Tutor tu = _db.Tutors.Where(t => t.EmailId == tvm.EmailId).FirstOrDefault();
            tu.Name = tvm.Name;
            tu.DOB = tvm.DOB;
            tu.Nationality = tvm.Nationality;
            tu.HourlyRate = tvm.HourlyRate;
            tu.Contact = tvm.Contact;
            tu.EmailId = tvm.EmailId;
            if (tvm.Photo != "")
            {
                tu.Photo = tvm.Photo;
            }
            tu.Address = tvm.Address;
            tu.SubjectId = tvm.SubjectId;

           
          
           

            Qualification qf = _db.Qualifications.Where(t => t.TutorId == tu.TutorId).FirstOrDefault();
           
            qf.Instution = tvm.Instution;
            qf.Board = tvm.Board;
            qf.StartDate = tvm.StartDate;
            qf.EndDate = tvm.EndDate;
            qf.CGPA = tvm.CGPA;
           return _db.SaveChanges();
        }
        public TutorViewModel GetTutorbyTutorId(int tutorid)
        {
            Tutor tu = _db.Tutors.Where(s => s.TutorId == tutorid).FirstOrDefault();
            TutorViewModel tvm = new TutorViewModel();
            tvm.TutorId = tu.TutorId;
            tvm.Name = tu.Name;
            tvm.DOB = tu.DOB;
            tvm.Nationality = tu.Nationality;
            tvm.HourlyRate = tu.HourlyRate;
            return tvm;
        }
        public TutorViewModel GetTutorbyEmailId(string emaild)
        {
            Tutor tu = _db.Tutors.Where(s => s.EmailId == emaild).FirstOrDefault();
             TutorViewModel tvm = new TutorViewModel();
            if (tu != null)
            {
                Qualification qf = _db.Qualifications.Where(q => q.TutorId == tu.TutorId).FirstOrDefault();
               
                if (tu != null)
                {

                    tvm.TutorId = tu.TutorId;
                    tvm.Name = tu.Name;
                    tvm.DOB = tu.DOB;
                    tvm.Nationality = tu.Nationality;
                    tvm.HourlyRate = tu.HourlyRate;

                    tvm.Contact = tu.Contact;
                    tvm.Photo = tu.Photo;
                    tvm.Address = tu.Address;
                    tvm.SubjectId = tu.SubjectId;

                    if (qf != null)
                    {
                        tvm.Instution = qf.Instution;
                        tvm.Board = qf.Board;
                        tvm.StartDate = qf.StartDate;
                        tvm.EndDate = qf.EndDate;
                        tvm.CGPA = qf.CGPA;
                    }

                }
               
            }
            return tvm;
           


        }
    }
}