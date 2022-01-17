using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HospitalLibrary.Shared.Model;

namespace HospitalLibrary.Schedule.Repository
{
    public class VisitDbRepository : GenericDbRepository<Visit>, IVisitRepository
    {
        private readonly HospitalDbContext _dbContext;

        public VisitDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Visit> CancelVisits(List<VisitTime> visitTimes, string doctorId)
        {
            throw new NotImplementedException();
        }

        public List<Visit> GetPatientsVisits(string id)
        {
            throw new NotImplementedException();
        }

        public List<Visit> GetVisitsByUsername(string username)
        {
            return _dbContext.Visits.Where(v => v.DoctorId.Equals(username) || v.PatientId.Equals(username)).ToList();     
        }

        public bool CheckIfDoctorBusy(Visit visit)
        {
            if (_dbContext.Visits.Count(v => v.DoctorId == visit.DoctorId && v.StartTime == visit.StartTime) == 0) return false;
            return true;
        }

        public bool CheckIfPatientBusy(Visit visit)
        {
            if (_dbContext.Visits.Count(v => v.PatientId == visit.PatientId && v.StartTime == visit.StartTime) == 0) return false;
            return true;
        }

        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime begining, DateTime ending, string doctorId)
        {
            return _dbContext.Visits.Where(v => v.StartTime >= begining && v.EndTime <= ending && v.DoctorId == doctorId 
                    && v.EndTime > DateTime.Now && !v.IsCanceled).ToList();
        }

        public List<Visit> GetAllVisits()
        {
            return _dbContext.Visits.ToList();
        }

        public List<Visit> GetVisitsForRoom(int roomId)
        {
            return _dbContext.Visits.Where(v => v.Doctor.RoomId == roomId).ToList();
        }

        public AppointmentReport GetReport(int id)
        {
            return _dbContext.Reports.Where(r=> r.AppointmentId == id).SingleOrDefault();
        }

        public AppointmentPrescription GetPrescription(int id)
        {
            return _dbContext.AppointmentPrescriptions.Where(p => p.AppointmentId == id).SingleOrDefault();
        }
    }
}
