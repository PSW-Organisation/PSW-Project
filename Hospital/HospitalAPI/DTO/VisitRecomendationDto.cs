using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class VisitRecomendationDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DoctorId { get; set; }
        public bool Priority { get; set; }
        public bool IsVisitScheduleByPriority { get; set; }
    }
}
