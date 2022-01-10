using ehealthcare.Model;
using ehealthcare.Repository;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public class OnCallShiftRepository : GenericDbRepository<OnCallShift>, IOnCallShiftRepository
    {
        private readonly HospitalDbContext _dbContext;
        public OnCallShiftRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OnCallShift> GetAllOnCallShiftByDoctorId(string doctorId)
        {
            return _dbContext.OnCallShifts.Where(onCallShift => onCallShift.DoctorId.Equals(doctorId)).ToList();
        }

        public List<Doctor> GetDoctorsOnCallShift(DateTime date)
        {
            return (from onCallShift in GetCallShiftsByDate(date) from doctor in _dbContext.Doctors where doctor.Id.Equals(onCallShift.DoctorId) select doctor).ToList();
        }

        public List<OnCallShift> GetCallShiftsByDate(DateTime date)
        {
            return _dbContext.OnCallShifts.Where(onCallShift => onCallShift.Date.Equals(date)).ToList();
        }

        public List<Doctor> GetDoctorsNotOnCallShift(DateTime date)
        {
            return (from onCallShift in GetCallShiftsByDate(date) from doctor in _dbContext.Doctors where !doctor.Id.Equals(onCallShift.DoctorId) select doctor).ToList();
        }
    }
}