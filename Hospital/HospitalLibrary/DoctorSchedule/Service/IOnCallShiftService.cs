using System;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Model;

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

        public AppointmentCount GetOnCallCountYearly(string username);

        public AppointmentCount GetOnCallCountMonthly(string username);
        public AppointmentCount GetOnCallCountWeekly(string username);

        public AppointmentCount GetOnCallCountDaily(string username);

        public int[] countYear(DateTime today, OnCallShift v, int[] count, int year);
        public int[] countMonth(DateTime today, OnCallShift v, int[] count, int month);
        public int[] countWeek(DateTime today, OnCallShift v, int[] count, int week);
        public int[] countDay(DateTime today, OnCallShift v, int[] count, int hour);
    }
}