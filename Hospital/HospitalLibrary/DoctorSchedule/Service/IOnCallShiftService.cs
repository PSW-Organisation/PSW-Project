using System;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public interface IOnCallShiftService
    {
        OnCallShift CreateOnCallShift(OnCallShift onCallShift);

        IList<OnCallShift> GetAllOnCallShifts();

        OnCallShift UpdateOnCallShift(OnCallShift onCallShift);

        bool DeleteOnCallShift(OnCallShift onCallShift);

        List<OnCallShift> GetAllOnCallShiftByDoctorId(string doctorId);

        List<Doctor> GetDoctorsOnCallShifts(DateTime date);

        List<Doctor> GetDoctorsNotOnCallShift(DateTime date);
    }
}