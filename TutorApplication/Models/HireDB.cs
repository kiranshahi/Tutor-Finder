using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class HireDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public int InsertHire(HireViewModel hvm)
        {
            Hire hr = new Hire();
            hr.Tutorid = hvm.Tutorid;
            hr.StudentId = hvm.StudentId;
            hr.ScheduleId = hvm.ScheduleId;
            hr.StartDate = hvm.StartDate;
            hr.EndDate = hvm.EndDate;
            hr.TotalFee = hvm.TotalFee;

            _db.Hires.Add(hr);
            return _db.SaveChanges();
            

        }
        //public int Get(HireViewModel hvm)
        //{
        //    Hire hr = new Hire();
        //    hr.Tutorid = hvm.HireId;
        //    hr.StudentId = hvm.StudentId;
        //    hr.ScheduleId = hvm.ScheduleId;
        //    hr.StartDate = hvm.StartDate;
        //    hr.EndDate = hvm.EndDate;
        //    hr.TotalFee = hvm.TotalFee;

        //    _db.Hires.Add(hr);
        //    return _db.SaveChanges();


        //}
        public List<Hire> GetHiredByStudentId(int studentid)
        {
            var hires = _db.Hires.Where(h => h.StudentId == studentid).ToList();

            return hires;
        }
        public List<Hire> GetTutorHiredByStudent(int teacherid)
        {
            var hires = _db.Hires.Where(h => h.Tutorid == teacherid).ToList();

            return hires;
        }
        public Hire GetDetailsByHireId(int hireid)
        {
            var hires = _db.Hires.Where(h => h.HireId == hireid).FirstOrDefault();

            return hires;
        }
    }
}