using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class VisitDto
    {
        //public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public VisitType VisitType { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public string PatientId { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsCanceled { get; set; }
    }
}
