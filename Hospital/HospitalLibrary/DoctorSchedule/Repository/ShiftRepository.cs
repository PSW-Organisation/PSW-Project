using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public class ShiftRepository : GenericDbRepository<Shift>, IShiftRepository
    {
        private readonly HospitalDbContext _dbContext;

        public ShiftRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
