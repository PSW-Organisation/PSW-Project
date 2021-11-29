using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Model
{
    public class VisitRecommendation
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DoctorId { get; set; }
        public bool Priority { get; set; }
        public bool IsVisitScheduleByPriority { get; set; }

        public VisitRecommendation() {}

        public VisitRecommendation(DateTime startTime, DateTime endTime, string doctorId, bool priority, bool isVisitScheduleByPriority)
        {
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
            Priority = priority;
            IsVisitScheduleByPriority = isVisitScheduleByPriority;
        }
    }
}
