using ehealthcare.Model;
using HospitalLibrary.Schedule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.Schedule.Model;
using HospitalLibrary.Model;

namespace HospitalLibrary.Schedule.Service
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IDoctorRepository _doctorRepository;

        public VisitService(IVisitRepository visitRepository, IDoctorRepository doctorRepository)
        {
            _visitRepository = visitRepository;
            _doctorRepository = doctorRepository;
        }

        public List<Visit> GetVisitsByUsername(string username)
        {
            return _visitRepository.GetVisitsByUsername(username);
        }
        public AppointmentCount GetPatientsCountYearly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            List<Visit> year1 = new List<Visit>();
            List<Visit> year2 = new List<Visit>();
            List<Visit> year3 = new List<Visit>();
            List<Visit> year4 = new List<Visit>();
            int[] count = new int[4];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                if (v.StartTime.Year == today.Year-2)
                {
                    year1.Add(v);
                }
                if (v.StartTime.Year == today.Year - 1)
                {
                    year2.Add(v);
                }
                if (v.StartTime.Year == today.Year)
                {
                    year3.Add(v);
                }
                if (v.StartTime.Year == today.Year)
                {
                    year4.Add(v);
                }
            }

            count[0] = year1.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[1] = year2.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[2] = year3.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[3] = year4.Select(c => c.PatientId != null).Distinct().ToList().Count;
            appCount.YearlySum = count;
            return appCount;
        }


        public AppointmentCount GetPatientsCountMonthly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            List<Visit> month1 = new List<Visit>();
            List<Visit> month2 = new List<Visit>();
            List<Visit> month3 = new List<Visit>();
            List<Visit> month4 = new List<Visit>();
            List<Visit> month5 = new List<Visit>();
            List<Visit> month6 = new List<Visit>();
            List<Visit> month7 = new List<Visit>();
            List<Visit> month8 = new List<Visit>();
            List<Visit> month9 = new List<Visit>();
            List<Visit> month10 = new List<Visit>();
            List<Visit> month11 = new List<Visit>();
            List<Visit> month12 = new List<Visit>();
            int[] count = new int[12];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 1)
                {
                    month1.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 2)
                {
                    month2.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 3)
                {
                    month3.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 4)
                {
                    month4.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 5)
                {
                    month5.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 6)
                {
                    month6.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 7)
                {
                    month7.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 8)
                {
                    month8.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 9)
                {
                    month9.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 10)
                {
                    month10.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 11)
                {
                    month11.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == 12)
                {
                    month12.Add(v);
                }
            }

            count[0] = month1.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[1] = month2.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[2] = month3.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[3] = month4.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[4] = month5.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[5] = month6.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[6] = month7.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[7] = month8.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[8] = month9.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[9] = month10.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[10] = month11.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[11] = month12.Select(c => c.PatientId != null).Distinct().ToList().Count;

            appCount.MonthlySum = count;
            return appCount;
        }


        public AppointmentCount GetPatientsCountWeekly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            List<Visit> week1 = new List<Visit>();
            List<Visit> week2 = new List<Visit>();
            List<Visit> week3 = new List<Visit>();
            List<Visit> week4 = new List<Visit>();
            int[] count = new int[4];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day >= 0 && v.StartTime.Day < 7)
                {
                    week1.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day >= 7 && v.StartTime.Day < 14)
                {
                    week2.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day >= 14 && v.StartTime.Day < 21)
                {
                    week3.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day >= 21)
                {
                    week4.Add(v);
                }
            }

            count[0] = week1.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[1] = week2.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[2] = week3.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[3] = week4.Select(c => c.PatientId != null).Distinct().ToList().Count;
            appCount.WeeklySum = count;
            return appCount;
        }



        public AppointmentCount GetPatientsCountDaily(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            List<Visit> hour0 = new List<Visit>();
            List<Visit> hour1 = new List<Visit>();
            List<Visit> hour2 = new List<Visit>();
            List<Visit> hour3 = new List<Visit>();
            List<Visit> hour4 = new List<Visit>();
            List<Visit> hour5 = new List<Visit>();
            List<Visit> hour6 = new List<Visit>();
            List<Visit> hour7 = new List<Visit>();
            List<Visit> hour8 = new List<Visit>();
            List<Visit> hour9 = new List<Visit>();
            List<Visit> hour10 = new List<Visit>();
            List<Visit> hour11 = new List<Visit>();
            List<Visit> hour12 = new List<Visit>();
            List<Visit> hour13 = new List<Visit>();
            List<Visit> hour14 = new List<Visit>();
            List<Visit> hour15 = new List<Visit>();
            List<Visit> hour16 = new List<Visit>();
            List<Visit> hour17 = new List<Visit>();
            List<Visit> hour18 = new List<Visit>();
            List<Visit> hour19 = new List<Visit>();
            List<Visit> hour20 = new List<Visit>();
            List<Visit> hour21 = new List<Visit>();
            List<Visit> hour22 = new List<Visit>();
            List<Visit> hour23 = new List<Visit>();
            int[] count = new int[24];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 0 && v.StartTime.Hour < 1)
                {
                    hour0.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 1 && v.StartTime.Hour < 2)
                {
                    hour1.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 2 && v.StartTime.Hour < 3)
                {
                    hour2.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 3 && v.StartTime.Hour < 4)
                {
                    hour3.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 4 && v.StartTime.Hour < 5)
                {
                    hour4.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 5 && v.StartTime.Hour < 6)
                {
                    hour5.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 6 && v.StartTime.Hour < 7)
                {
                    hour6.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 7 && v.StartTime.Hour < 8)
                {
                    hour7.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 8 && v.StartTime.Hour < 9)
                {
                    hour8.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 9 && v.StartTime.Hour < 10)
                {
                    hour9.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 10 && v.StartTime.Hour < 11)
                {
                    hour10.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 11 && v.StartTime.Hour < 12)
                {
                    hour11.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 12 && v.StartTime.Hour < 13)
                {
                    hour12.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 13 && v.StartTime.Hour < 14)
                {
                    hour13.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 14 && v.StartTime.Hour < 15)
                {
                    hour14.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 15 && v.StartTime.Hour < 16)
                {
                    hour15.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 16 && v.StartTime.Hour < 17)
                {
                    hour16.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 17 && v.StartTime.Hour < 18)
                {
                    hour17.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 18 && v.StartTime.Hour < 19)
                {
                    hour18.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 19 && v.StartTime.Hour < 20)
                {
                    hour19.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 20 && v.StartTime.Hour < 21)
                {
                    hour20.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 21 && v.StartTime.Hour < 22)
                {
                    hour21.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 22 && v.StartTime.Hour < 23)
                {
                    hour22.Add(v);
                }
                if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= 23)
                {
                    hour23.Add(v);
                }


            }

            count[0] = hour0.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[1] = hour1.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[2] = hour2.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[3] = hour3.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[4] = hour4.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[5] = hour5.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[6] = hour6.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[7] = hour7.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[8] = hour8.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[9] = hour9.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[10] = hour10.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[11] = hour11.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[12] = hour12.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[13] = hour13.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[14] = hour14.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[15] = hour15.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[16] = hour16.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[17] = hour17.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[18] = hour18.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[19] = hour19.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[20] = hour20.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[21] = hour21.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[22] = hour22.Select(c => c.PatientId != null).Distinct().ToList().Count;
            count[23] = hour23.Select(c => c.PatientId != null).Distinct().ToList().Count;
            appCount.DailySum = count;
            return appCount;
        }

        public AppointmentCount GetVisitsCountYearly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            int[] count = new int[4];
            DateTime today = DateTime.Now;
            foreach(Visit v in doctorVisits)
            {
                for (int i = 0; i <= 3; i++)
                {
                    count = countYear(today,v,count,i);
                }
            }
            appCount.YearlySum = count;
            return appCount;
        }

        public int[] countYear(DateTime today, Visit v, int[] count, int year)
        {
            if (v.StartTime.Year == today.Year + year - 2)
            {
                count[year] += 1;
            }
            return count;
        }

        public AppointmentCount GetVisitsCountMonthly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            int[] count = new int[12];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                for (int i = 1; i <= 12; i++) {
                    count = countMonth(today, v, count, i);
                }
               
            }
            appCount.MonthlySum = count;
            return appCount;
        }

        public int[] countMonth(DateTime today,Visit v,int[] count,int month)
        {
            if (v.StartTime.Year == today.Year && v.StartTime.Month == month)
            {
                count[month-1] += 1;
            }
            return count;
        }




        public AppointmentCount GetVisitsCountWeekly(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            int[] count = new int[4];
            DateTime today = DateTime.Now;
            foreach (Visit v in doctorVisits)
            {
                for (int i = 1; i <= 4; i++)
                {
                    count = countWeek(today, v, count, i);
                }

            }
            appCount.WeeklySum= count;
            return appCount;
        }

        public int[] countWeek(DateTime today, Visit v, int[] count, int week)
        {
            var lastDayOfMonth = DateTime.DaysInMonth(today.Year, today.Month);
            if (v.StartTime.Year == today.Year && v.StartTime.Month ==today.Month && v.StartTime.Day >= (week-1)*7 && v.StartTime.Day < week *7)
            {
                count[week - 1] += 1;
            }
            else if(v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day >= 4 * 7 && v.StartTime.Day <= lastDayOfMonth)
            {
                count[3] += 1;
            }
            return count;
        }


        public AppointmentCount GetVisitsCountDaily(string username)
        {
            AppointmentCount appCount = new AppointmentCount();
            List<Visit> doctorVisits = GetVisitsByUsername(username);
            DateTime today = DateTime.Now;
            int lastDayOfMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int[] count = new int[24];
            foreach (Visit v in doctorVisits)
            {
                for (int i = 1; i <= 24; i++)
                {
                    count = countDay(today, v, count, i);
                }

            }
            appCount.DailySum = count;
            return appCount;
        }

        public int[] countDay(DateTime today, Visit v, int[] count, int hour)
        {
            if (v.StartTime.Year == today.Year && v.StartTime.Month == today.Month && v.StartTime.Day == today.Day && v.StartTime.Hour >= hour && v.StartTime.Hour < hour+1)
            {
                count[hour - 1] += 1;
            }
            return count;
        }



        public Visit GetVisitById(int id)
        {
           return _visitRepository.Get(id);
        }

        public bool AddVisit(Visit newVisit)
        {
            if(CheckIfDoctorBusy(newVisit)) return false;
            if(CheckIfPatientBusy(newVisit)) return false;
            _visitRepository.Insert(newVisit);
            return true;
        }

        public bool CheckIfDoctorBusy(Visit visit)
        {
            if (_visitRepository.CheckIfDoctorBusy(visit))
                return true;
            return false;
        }

        public bool CheckIfPatientBusy(Visit visit)
        {
            if (_visitRepository.CheckIfPatientBusy(visit))
                return true;
            return false;
        }

        public void CancelVisit(Visit visit)
        {
            visit.IsCanceled = true;
           _visitRepository.Update(visit);
        }

        public List<Visit> GetАllGeneratedFreeVisits(VisitRecommendation recommendation)
        {
            return GetGeneratedFreeVisitsByDate(recommendation);
        }

        private List<Visit> GetGeneratedFreeVisitsByDate(VisitRecommendation recommendation)
        {
            if (recommendation.IsVisitScheduleByPriority)  return GetGeneratedFreeVisits(recommendation);
            return GetFreeGeneratedVisitsByDoctor(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);
        }

        private List<Visit> GetGeneratedFreeVisits(VisitRecommendation recommendation)
        {
            List<Visit> generatedFreeVisits = new List<Visit>();
            while (generatedFreeVisits.Count == 0)
            {
                if (HasRecommendationStartTimePassed(recommendation)) generatedFreeVisits = GetGeneratedFreeVisitsByPriority(recommendation);
                else
                {
                    recommendation.StartTime = recommendation.StartTime.AddDays(1);
                    generatedFreeVisits = GetGeneratedFreeVisitsByPriority(recommendation);
                }
                recommendation.StartTime = recommendation.StartTime.AddDays(-1);
                recommendation.EndTime = recommendation.EndTime.AddDays(1);
            }

            return generatedFreeVisits;
        }

        private static bool HasRecommendationStartTimePassed(VisitRecommendation recommendation)
        {
            return recommendation.StartTime > DateTime.Now;
        }

        private List<Visit> GetGeneratedFreeVisitsByPriority(VisitRecommendation recommendation)
        {
            List<Visit> generatedFreeVisits = new List<Visit>();
            if (recommendation.Priority) generatedFreeVisits = GetFreeGeneratedVisitsByDate(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);
            else generatedFreeVisits = GetFreeGeneratedVisitsByDoctor(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);

            return generatedFreeVisits;
        }

        private List<Visit> GetFreeGeneratedVisitsByDoctor(DateTime begining, DateTime ending, string doctorId)
        {
            List<Visit> generatedVisits = GetGeneratedVisits(begining, ending);
            List<Visit> generatedVisitsByDoctor = new List<Visit>();
            List<Visit> visits = _visitRepository.GetAllVisits();
            Doctor doctor = _doctorRepository.GetDoctorById(doctorId);
            foreach (var generatedVisit in generatedVisits)
            {
                generatedVisitsByDoctor = GetGeneratedVisitsByDoctor(doctorId, generatedVisitsByDoctor, visits, doctor, generatedVisit);
            }
            return generatedVisitsByDoctor;
        }

        private static List<Visit> GetGeneratedVisitsByDoctor(string doctorId, List<Visit> generatedVisitsByDoctor, List<Visit> visits, Doctor doctor, Visit generatedVisit)
        {
            if (!IsDoctorAdded(doctorId, visits, generatedVisit))
                generatedVisitsByDoctor.Add(new Visit(generatedVisit.StartTime, generatedVisit.EndTime, VisitType.examination,
                            doctor, doctorId, null, "", false, false));

            return generatedVisitsByDoctor;
        }

        private static bool IsDoctorAdded(string doctorId, List<Visit> visits, Visit generatedVisit)
        {
            bool doctorIsAdded = false;
            foreach (var visit in visits)
                if (visit.DoctorId.Equals(doctorId) && IsVisitForthcoming(generatedVisit, visit)) doctorIsAdded = true;

            return doctorIsAdded;
        }

        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime begining, DateTime ending, string doctorId)
        {
            return _visitRepository.GetForthcomingVisitsByDateAndDoctor(begining, ending, doctorId);
        }

        private List<Visit> GetFreeGeneratedVisitsByDate(DateTime begining, DateTime ending, string doctorId)
        {
            return GetGeneratedVisitsByDate(GetGeneratedVisits(begining, ending), _visitRepository.GetAllVisits(), 
                GetFillteredDoctors(_doctorRepository.GetAllDoctors(), _doctorRepository.GetDoctorById(doctorId)));
        }

        private static List<Doctor> GetFillteredDoctors(List<Doctor> doctors, Doctor selectedDoctor)
        {
            List<Doctor> filteredDoctors = new List<Doctor>();
            foreach (var doctor in doctors)
            {
                if (selectedDoctor.Specialization == doctor.Specialization)
                    filteredDoctors.Add(doctor);
            }
            return filteredDoctors;
        }

        private static List<Visit> GetGeneratedVisitsByDate(List<Visit> generatedVisits, List<Visit> visits, List<Doctor> filteredDoctors)
        {
            List<Visit> generatedVisitsByDate = new List<Visit>();
            foreach (var generatedVisit in generatedVisits)
            {
                generatedVisitsByDate = GetAddedVisitsByDate(generatedVisitsByDate, visits, filteredDoctors, generatedVisit);
            }
            return generatedVisitsByDate;
        }

        private static List<Visit> GetAddedVisitsByDate(List<Visit> generatedVisitsByDate, List<Visit> visits, List<Doctor> filteredDoctors, Visit generatedVisit)
        {
            foreach (var doctor in filteredDoctors)
            {
                generatedVisitsByDate = GetAddedGeneratedVisitsByDate(generatedVisitsByDate, visits, generatedVisit, doctor);
            }
            return generatedVisitsByDate;
        }

        private static List<Visit> GetAddedGeneratedVisitsByDate(List<Visit> generatedVisitsByDate, List<Visit> visits, Visit generatedVisit, Doctor doctor)
        {
            if (!IsDoctorAdded(visits, generatedVisit, doctor))
            {
                doctor.Password = "";
                generatedVisitsByDate.Add(new Visit(generatedVisit.StartTime, generatedVisit.EndTime, VisitType.examination,
                            doctor, doctor.Username, null, "", false, false));
            }
            return generatedVisitsByDate;
        }

        private static bool IsDoctorAdded(List<Visit> visits, Visit generatedVisit, Doctor doctor)
        {
            bool doctorIsAdded = false;
            foreach (var visit in visits)
            {
                if (doctor.Id.Equals(visit.DoctorId))
                {
                    if (IsVisitForthcoming(generatedVisit, visit)) doctorIsAdded = true;
                }
            }

            return doctorIsAdded;
        }

        private static bool IsVisitForthcoming(Visit generatedVisit, Visit visit)
        {
            return visit.StartTime == generatedVisit.StartTime && visit.EndTime > DateTime.Now && !visit.IsCanceled;
        }

        private List<Visit> GetGeneratedVisits(DateTime begining, DateTime ending)
        {
            begining = new DateTime(begining.Year, begining.Month, begining.Day, 08, 00, 00);
            ending = new DateTime(ending.Year, ending.Month, ending.Day, 08, 00, 00);
            DateTime startOfShift = new DateTime(begining.Year, begining.Month, begining.Day, 08, 00, 00);
            DateTime endOfShift = startOfShift;
            List<Visit> generatedVisits = new List<Visit>();
            bool whileBreak = true;
            while (whileBreak)
            {
                if (IsStartOfShiftBetweenBeginingAndEnding(startOfShift, begining, ending)) whileBreak = false;
                else {
                    for (int i = 0; i < 16; i++)
                    {
                        endOfShift = startOfShift.AddMinutes(30);
                        generatedVisits.Add(new Visit(startOfShift, endOfShift, VisitType.examination,
                                    null, "", null, "", false, false));
                        startOfShift = startOfShift.AddMinutes(30);
                    }
                    startOfShift = new DateTime(startOfShift.Year, startOfShift.Month, startOfShift.Day, 08, 00, 00);
                    startOfShift = startOfShift.AddDays(1);
                    endOfShift = startOfShift;
                }
            }
            return generatedVisits;
        }

        public void ReviewVisit(Visit visitForUpdate)
        {
            visitForUpdate.IsReviewed = true;
            _visitRepository.Update(visitForUpdate);
        }

        private bool IsStartOfShiftBetweenBeginingAndEnding(DateTime startOfShift, DateTime begining, DateTime ending)
        {
            return startOfShift > ending;
        }

        public List<Visit> GetVisitsForRoom(int roomId)
        {
            return _visitRepository.GetVisitsForRoom(roomId);
        }
    }
}
