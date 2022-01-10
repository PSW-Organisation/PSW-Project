using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using System;
using System.Collections.Generic;
using HospitalLibrary.DoctorSchedule.Repository;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class OnCallShiftService : IOnCallShiftService
    {
        private readonly IOnCallShiftRepository _onCallShiftRepository;

        public OnCallShiftService(IOnCallShiftRepository onCallShiftRepository)
        {
            _onCallShiftRepository = onCallShiftRepository;
        }

        public OnCallShift CreateOnCallShift(OnCallShift onCallShift)
        {
            foreach(OnCallShift onCall in GetAllOnCallShiftByDoctorId(onCallShift.DoctorId))
            {
                if (!onCallShift.Date.Equals(onCall.Date))
                    _onCallShiftRepository.Insert(onCallShift);
                else return null;
            }
            return onCallShift;
        }

        public bool DeleteOnCallShift(OnCallShift onCallShift)
        {
            _onCallShiftRepository.Delete(onCallShift);
            return true;
        }

        public List<OnCallShift> GetAllOnCallShiftByDoctorId(string doctorId)
        {
            return _onCallShiftRepository.GetAllOnCallShiftByDoctorId(doctorId);
        }

        public IList<OnCallShift> GetAllOnCallShifts()
        {
            return _onCallShiftRepository.GetAll();
        }

        public List<Doctor> GetDoctorsOnCallShifts(DateTime date)
        {
            return _onCallShiftRepository.GetDoctorsOnCallShift(date);
        }

        public List<Doctor> GetDoctorsNotOnCallShift(DateTime date)
        {
            return _onCallShiftRepository.GetDoctorsNotOnCallShift(date);
        }

        public OnCallShift UpdateOnCallShift(OnCallShift onCallShift)
        {
            return _onCallShiftRepository.Update(onCallShift);
        }
    }
}