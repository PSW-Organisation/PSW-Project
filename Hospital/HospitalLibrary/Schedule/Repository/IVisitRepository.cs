using ehealthcare.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Repository
{
    public interface IVisitRepository : IGenericRepository<Visit>
    {
        public List<Visit> GetPatientsVisits(String id);
        public List<Visit> CancelVisits(List<VisitTime> visitTimes, string doctorId);
        public List<Visit> GetVisitsByUsername(string username);
        public bool CheckIfDoctorBusy(Visit visit);
        public bool CheckIfPatientBusy(Visit visit);
        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime begining, DateTime ending, string doctorId);
        public List<Visit> GetAllVisits();
    }
}
