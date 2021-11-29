using ehealthcare.Proxies;
using ehealthcare.Service;
using HospitalLibrary.Model;
using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class Visit : EntityDb
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public VisitType VisitType { get; set; }
        public virtual Doctor Doctor { get; set; }
        public String DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public String PatientId { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsCanceled { get; set; }

        public Visit()
        {

        }

        public Visit(DateTime startTime, DateTime endTime, VisitType visitType,
            Doctor doctor, string doctorId, Patient patient, string patientId, bool isReviewed, bool isCanceled)
        {
            StartTime = startTime;
            EndTime = endTime;
            VisitType = visitType;
            Doctor = doctor;
            DoctorId = doctorId;
            Patient = patient;
            PatientId = patientId;
            IsReviewed = isReviewed;
            IsCanceled = isCanceled;
        }
    }
}
