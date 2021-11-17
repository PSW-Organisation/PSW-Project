using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IVisitService
    {
        public List<Visit> GetVisitsForPatient(int id);
        public void ScheduleNewVisit(Visit newVisit);
        public void UpdateVisitInStorage(Visit newVisit);
        public void MarkVisitsIfPatientDidntCome(int id);
        public void CancelVisit(Visit visit);
        public void MarkVisitAsRated(Visit visit);
        public List<int> GetNumberOfVisitsPerMonthForPatient(int id);
        public bool IsVisitInNextThreeDays(Visit visit);
        public Visit GetVisitById(int id);
        public void DelayVisit(int id, VisitTime delayedVisitTime);
        public List<Visit> GetPatientsVisits(int id);
        public Visit GetVisit(int doctorId, VisitTime visitTime);
        public List<Visit> GetAllVisits();
        public void ScheduleNewExam(Visit visit);
        public List<Visit> GetVisitByType(VisitType visitType);
        public void CancelOperation(Visit visit);
        public List<Visit> GetCompletedPatientsVisits(int id);
        public Visit GetMostRecentPatientVisitId(int id);
    }
}
