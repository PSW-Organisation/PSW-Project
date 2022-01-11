using ehealthcare.Model;
using ehealthcare.Repository;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.MedicalRecord.Repository;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public class OnCallShiftRepository : GenericDbRepository<OnCallShift>, IOnCallShiftRepository
    {
        private readonly HospitalDbContext _dbContext;
        private readonly IDoctorRepository _doctorRepository;

        public OnCallShiftRepository(HospitalDbContext dbContext, IDoctorRepository doctorRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _doctorRepository = doctorRepository;
        }

        public int GetNewId()
        {
            return _dbContext.Rooms.Max(x => x.Id) + 1;
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
            return _dbContext.OnCallShifts.Where(onCallShift => onCallShift.Date.Year == date.Year && onCallShift.Date.Month == date.Month && onCallShift.Date.Day == date.Day).ToList();
        }

        public OnCallShift GetAllOnCallShiftByDateAndDoctor(DateTime date,string doctorId)
        {
            OnCallShift onCallShift = new OnCallShift();
            foreach (OnCallShift onCall in _dbContext.OnCallShifts.ToList())
            {
                if (onCall.Date.Year == date.Year && onCall.Date.Month == date.Month && onCall.Date.Day == date.Day && onCall.DoctorId == doctorId)
                    return onCall;
            }
            return onCallShift;
        }

        public List<Doctor> GetDoctorsNotOnCallShift(DateTime date)
        {
            bool notOnShift = true;
            List<Doctor> doctorsNotOnShift = new List<Doctor>();
            foreach (var doctor in _doctorRepository.GetAll())
            {
                foreach (var doctorOnShift in GetDoctorsOnCallShift(date))
                {
                    if (doctor.Id == doctorOnShift.Id)
                    {
                        notOnShift = false;
                        break;
                    }
                }
                if(notOnShift)
                    doctorsNotOnShift.Add(doctor);
                notOnShift = true;
            }
            

            //if (GetCallShiftsByDate(date).Count <= 0)
            //    return _dbContext.Doctors.ToList();

            //foreach (OnCallShift onCallShift in GetCallShiftsByDate(date))
            //foreach (var doctor in _dbContext.Doctors)
            //{
            //    if (!doctor.Id.Equals(onCallShift.DoctorId)) list.Add(doctor);
            //}

            return doctorsNotOnShift;
        }
    }
}