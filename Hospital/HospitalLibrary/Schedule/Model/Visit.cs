

using HospitalLibrary.Model;
using HospitalLibrary.Schedule.Model;
using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class Visit : EntityDb
    {
        public virtual VisitTimeInterval Interval { get; set; }
        public VisitType VisitType { get; set; }
        public virtual Doctor Doctor { get; set; }
        public String DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public String PatientId { get; set; }
        public virtual VisitStatus Status { get; set; }

        public Visit()
        {

        }

        public Visit(DateTime startTime, DateTime endTime, VisitType visitType,
            Doctor doctor, string doctorId, Patient patient, string patientId, bool isReviewed, bool isCanceled)
        {
            Interval = new VisitTimeInterval(this.Id, startTime, endTime);
            VisitType = visitType;
            Doctor = doctor;
            DoctorId = doctorId;
            Patient = patient;
            PatientId = patientId;
            Status = new VisitStatus(this.Id, isReviewed, isCanceled);
        }
    }
}
