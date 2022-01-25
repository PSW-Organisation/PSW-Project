using System.Collections.Generic;
using System.Linq;
using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public class DoctorVacationRepository : GenericDbRepository<DoctorVacation>, IDoctorVacationRepository
    {
        private readonly HospitalDbContext _dbContext;
        public DoctorVacationRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetNewId()
        {
            return _dbContext.Rooms.Max(x => x.Id) + 1;
        }

        public List<DoctorVacation> GetDoctorVacations(string doctorId)
        {
            return _dbContext.Schedules.Single(s => s.DoctorId == doctorId).DoctorVacations.Where(d => d.DoctorId.Equals(doctorId)).ToList();
        }

        public List<DoctorVacation> GetAllDoctorVacations()
        {
            List<DoctorVacation> doctorVacations = new List<DoctorVacation>();
            foreach(DoctorsSchedule doctorSchedule in _dbContext.Schedules)
                foreach (DoctorVacation doctorVacation in doctorSchedule.DoctorVacations)
                    doctorVacations.Add(doctorVacation);
            return doctorVacations;
        }

        public bool DeleteDoctorVacation(DoctorVacation doctorVacation)
        {
            _dbContext.Schedules.Single(s => s.DoctorId == doctorVacation.DoctorId).DoctorVacations.Remove(doctorVacation);
            return true;
        }
    }
}
