using ehealthcare.Model;
using HospitalLibrary.Model;
using HospitalLibrary.Schedule.Model;
using HospitalLibrary.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Service
{
    public interface IVisitService
    {
        public List<Visit> GetVisitsByUsername(string username);
        public AppointmentCount GetVisitsCountYearly(string username);
        public AppointmentCount GetVisitsCountMonthly(string username);
        public AppointmentCount GetVisitsCountWeekly(string username);
        public AppointmentCount GetVisitsCountDaily(string username);
        public AppointmentCount GetPatientsCountYearly(string username);
        public AppointmentCount GetPatientsCountMonthly(string username);
        public AppointmentCount GetPatientsCountWeekly(string username);

        public AppointmentCount GetPatientsCountDaily(string username);
        public int[] countYear(DateTime today, Visit v, int[] count, int year);
        public int[] countMonth(DateTime today, Visit v, int[] count, int month);
        public int[] countWeek(DateTime today, Visit v, int[] count, int week);
        public int[] countDay(DateTime today, Visit v, int[] count, int hour);
        public void CancelVisit(Visit visit);
        public Visit GetVisitById(int id);
        public bool AddVisit(Visit newVisit);
        public void ReviewVisit(Visit visitForUpdate);
        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime beginning, DateTime ending, string doctorId);
        public List<Visit> GetАllGeneratedFreeVisits(VisitRecommendation recommendation);
        public List<Visit> GetVisitsForRoom(int roomId);
        public AppointmentReport GetReport(int id);
        public AppointmentPrescription GetPrescription(int id);
    }
}
