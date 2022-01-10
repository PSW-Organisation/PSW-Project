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
            return _dbContext.DoctorVacations.Where(d => d.DoctorId.Equals(doctorId)).ToList();
        }
    }
}
