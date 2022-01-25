using System;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public interface IOnCallShiftRepository : IGenericRepository<OnCallShift>
    {
        public int GetNewId();
        public List<Doctor> GetDoctorsOnCallShift(DateTime date);

        public List<Doctor> GetDoctorsNotOnCallShift(DateTime date);

        public List<OnCallShift> GetAllOnCallShiftByDoctorId(string doctorId);

        public OnCallShift GetAllOnCallShiftByDateAndDoctor(DateTime date, string doctorId);

        public List<OnCallShift> GetAllOnCallShifts();
    }
}