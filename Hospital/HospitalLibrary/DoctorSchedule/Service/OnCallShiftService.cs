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
            //if (GetAllOnCallShiftByDoctorId(onCallShift.DoctorId).Count < 1)
            //{
            //    _onCallShiftRepository.Insert(onCallShift);
            //    return onCallShift;
            //}
            //foreach (OnCallShift onCall in GetAllOnCallShiftByDoctorId(onCallShift.DoctorId))
            //{
            //    if (onCall.Date.Year != onCallShift.Date.Year || onCall.Date.Month != onCallShift.Date.Month ||
            //        onCall.Date.Day != onCallShift.Date.Day)
            //    {
             //       _onCallShiftRepository.GetNewId();
                    _onCallShiftRepository.Insert(onCallShift);
            //    }
            //    else return null;
            //}
            return onCallShift;
        }

        public bool DeleteOnCallShift(OnCallShift onCallShift)
        {
            OnCallShift onCall = _onCallShiftRepository.GetAllOnCallShiftByDateAndDoctor(onCallShift.Date, onCallShift.DoctorId);
            _onCallShiftRepository.Delete(onCall);
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