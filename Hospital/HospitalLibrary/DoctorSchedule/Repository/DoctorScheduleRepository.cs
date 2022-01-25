using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public class DoctorScheduleRepository : GenericDbRepository<DoctorsSchedule>, IDoctorScheduleRepository
    {
        private readonly HospitalDbContext _dbContext;

        public DoctorScheduleRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DoctorsSchedule GetDoctorsSchedule(string doctorId)
        {
            return _dbContext.Schedules.Single(d => d.DoctorId == doctorId);
        }

    }
}
