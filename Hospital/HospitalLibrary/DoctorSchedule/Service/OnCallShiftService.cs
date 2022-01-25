using ehealthcare.Model;
using HospitalLibrary.DoctorSchedule.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using HospitalLibrary.DoctorSchedule.Repository;
using HospitalLibrary.Model;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class OnCallShiftService : IOnCallShiftService
    {
        private readonly IOnCallShiftRepository _onCallShiftRepository;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public OnCallShiftService(IOnCallShiftRepository onCallShiftRepository, IDoctorScheduleRepository doctorScheduleRepository)
        {
            _onCallShiftRepository = onCallShiftRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public OnCallShift CreateOnCallShift(OnCallShift onCallShift)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(onCallShift.DoctorId);
            if (!doctorSchedule.AddOnCallShift(onCallShift))
                return null;
            _doctorScheduleRepository.Save(doctorSchedule);
            return onCallShift;
        }

        public bool DeleteOnCallShift(OnCallShift onCallShift)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(onCallShift.DoctorId);
            onCallShift.DoctorsScheduleId = doctorSchedule.Id;
            if (!doctorSchedule.DeleteOnCallShift(onCallShift))
                return false;
            _doctorScheduleRepository.Save(doctorSchedule);
            return true;
        }

        public List<OnCallShift> GetAllOnCallShiftByDoctorId(string doctorId)
        {
            return _onCallShiftRepository.GetAllOnCallShiftByDoctorId(doctorId);
        }

        public IList<OnCallShift> GetAllOnCallShifts()
        {
            return _onCallShiftRepository.GetAllOnCallShifts();
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
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(onCallShift.DoctorId);
            if (!doctorSchedule.UpdateOnCallShift(onCallShift))
                return null;
            _doctorScheduleRepository.Save(doctorSchedule);
            return onCallShift;
        }

        public AppointmentCount GetOnCallCountYearly(string username)
        {
                AppointmentCount appCount = new AppointmentCount();
                List<OnCallShift> doctorVisits = GetAllOnCallShiftByDoctorId(username);
                int[] count = new int[4];
                DateTime today = DateTime.Now;
                foreach (OnCallShift v in doctorVisits)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        count = countYear(today, v, count, i);
                    }
                }
                appCount.YearlySum = count;
                return appCount;
            }

            public int[] countYear(DateTime today, OnCallShift v, int[] count, int year)
            {
                if (v.Date.Year == today.Year + year - 2)
                {
                    count[year] += 1;
                }
                return count;
            }

            public AppointmentCount GetOnCallCountMonthly(string username)
            {
                AppointmentCount appCount = new AppointmentCount();
                List<OnCallShift> doctorVisits = GetAllOnCallShiftByDoctorId(username);
                int[] count = new int[12];
                DateTime today = DateTime.Now;
                foreach (OnCallShift v in doctorVisits)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        count = countMonth(today, v, count, i);
                    }

                }
                appCount.MonthlySum = count;
                return appCount;
            }

            public int[] countMonth(DateTime today, OnCallShift v, int[] count, int month)
            {
                if (v.Date.Year == today.Year && v.Date.Month == month)
                {
                    count[month - 1] += 1;
                }
                return count;
            }

            public AppointmentCount GetOnCallCountWeekly(string username)
            {
                AppointmentCount appCount = new AppointmentCount();
                List<OnCallShift> doctorVisits = GetAllOnCallShiftByDoctorId(username);
                int[] count = new int[4];
                DateTime today = DateTime.Now;
                foreach (OnCallShift v in doctorVisits)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        count = countWeek(today, v, count, i);
                    }

                }
                appCount.WeeklySum = count;
                return appCount;
            }

            public int[] countWeek(DateTime today, OnCallShift v, int[] count, int week)
            {
                var lastDayOfMonth = DateTime.DaysInMonth(today.Year, today.Month);
                if (v.Date.Year == today.Year && v.Date.Month == today.Month && v.Date.Day >= (week - 1) * 7 && v.Date.Day < week * 7)
                {
                    count[week - 1] += 1;
                }
                else if (v.Date.Year == today.Year && v.Date.Month == today.Month && v.Date.Day >= 4 * 7 && v.Date.Day <= lastDayOfMonth)
                {
                    count[3] += 1;
                }
                return count;
            }

            public AppointmentCount GetOnCallCountDaily(string username)
            {
                AppointmentCount appCount = new AppointmentCount();
                List<OnCallShift> doctorVisits = GetAllOnCallShiftByDoctorId(username);
                DateTime today = DateTime.Now;
                int lastDayOfMonth = DateTime.DaysInMonth(today.Year, today.Month);
                int[] count = new int[24];
                foreach (OnCallShift v in doctorVisits)
                {
                    for (int i = 1; i <= 24; i++)
                    {
                        count = countDay(today, v, count, i);
                    }

                }
                appCount.DailySum = count;
                return appCount;
            }

            public int[] countDay(DateTime today, OnCallShift v, int[] count, int hour)
            {
                if (v.Date.Year == today.Year && v.Date.Month == today.Month && v.Date.Day == today.Day && v.Date.Hour >= hour && v.Date.Hour < hour + 1)
                {
                    count[hour - 1] += 1;
                }
                return count;
            }



    }
}