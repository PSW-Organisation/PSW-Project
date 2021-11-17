using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class VisitController
	{
		private IVisitService visitService;

		public VisitController(IVisitService visitService)
		{
			this.visitService = visitService;
		}

		public List<Visit> GetVisitsForPatient(int id)
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

		public Visit GetVisitById(int id)
		{
			return visitService.GetVisitById(id);
		}

		public void DelayVisit(int id, VisitTime delayedVisitTime)
		{
			visitService.DelayVisit(id, delayedVisitTime);
		}

		public List<Visit> GetPatientsVisits(int id)
		{
			return visitService.GetPatientsVisits(id);
		}

		public void MarkVisitsIfPatientDidntCome(int id)
		{
			visitService.MarkVisitsIfPatientDidntCome(id);
		}

		public Visit GetVisit(int doctorId, VisitTime visitTime)
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

		public List<Visit> GetCompletedPatientsVisits(int id)
		{
			return visitService.GetCompletedPatientsVisits(id);
		}

		public List<int> GetNumberOfVisitsPerMonthForPatient(int id)
		{
			return visitService.GetNumberOfVisitsPerMonthForPatient(id);
		}

		public Visit GetMostRecentPatientVisitId(int id)
		{
			return visitService.GetMostRecentPatientVisitId(id);
		}
	}
}
