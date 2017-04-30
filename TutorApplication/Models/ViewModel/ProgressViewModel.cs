using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorApplication.Models.ViewModel
{
    public class ProgressViewModel
    {
        public int ProgressId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int ScheduleId { get; set; }
        public string  FromTime { get; set; }
        public string ToTime { get; set; }
        public string Comment { get; set; }
        public string PresentDate { get; set; }
    }
}