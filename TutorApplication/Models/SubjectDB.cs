using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApplication.Models.ViewModel;

namespace TutorApplication.Models
{
    public class SubjectDB
    {
        OnlineTutorEntities _db = new OnlineTutorEntities();
        public List<SubjectViewModel> GetAllSubject()
        {
            List<SubjectViewModel> lstsub = new List<SubjectViewModel>();
            var sub = _db.Subjects.ToList();
            foreach (var item in sub)
            {
                lstsub.Add(new SubjectViewModel() { SubjectId = item.SubjectId, SubjectName = item.SubjectName });

            }
            return lstsub;
        }
    }
}