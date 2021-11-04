using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class VisitController
    {
        private VisitService visitService;

        public VisitController()
        {
            visitService = new VisitService();
        }

        public List<Visit> GetVisitsForPatient(String id)
        {
            return visitService.GetVisitsForPatient(id);
        }

        public void ScheduleNewVisit(Visit newVisit)
        {
            visitService.ScheduleNewVisit(newVisit);
        }

        public void UpdateVisitInStorage(Visit newVisit)
        {
            visitService.UpdateVisitInStorage(newVisit);
        }

        public void CancelVisit(Visit visit)
        {
            visitService.CancelVisit(visit);
        }

        public void MarkVisitAsRated(Visit visit)
        {
            visitService.MarkVisitAsRated(visit);
        }

        public bool IsVisitInNextThreeDays(Visit visit)
        {
            return visitService.IsVisitInNextThreeDays(visit);
        }

        public Visit GetVisitById(string id)
        {
            return visitService.GetVisitById(id);
        }

        public void DelayVisit(string id, VisitTime delayedVisitTime)
        {
            visitService.DelayVisit(id, delayedVisitTime);
        }

        public List<Visit> GetPatientsVisits(String id)
        {
            return visitService.GetPatientsVisits(id);
        }

        public void MarkVisitsIfPatientDidntCome(string id)
        {
            visitService.MarkVisitsIfPatientDidntCome(id);
        }

        public Visit GetVisit(String doctorId, VisitTime visitTime)
        {
            return visitService.GetVisit(doctorId, visitTime);
        }

        public List<Visit> GetAllVisits()
        {
            return visitService.GetAllVisits();
        }

        public void ScheduleNewExam(Visit visit)
        {
            visitService.ScheduleNewExam(visit);
        }

        public List<Visit> GetVisitByType(VisitType visitType)
        {
            return visitService.GetVisitByType(visitType);
        }

        public void CancelOperation(Visit visit)
        {
            visitService.CancelOperation(visit);
        }

        public List<Visit> GetCompletedPatientsVisits(String id)
        {
            return visitService.GetCompletedPatientsVisits(id);
        }

        public List<int> GetNumberOfVisitsPerMonthForPatient(string id)
        {
            return visitService.GetNumberOfVisitsPerMonthForPatient(id);
        }

        public Visit GetMostRecentPatientVisitId(String id)
        {
            return visitService.GetMostRecentPatientVisitId(id);
        }
    }
}
