using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehealthcare.Service
{
	public class VisitService
	{
		private VisitRepository visitRepository;
		private PatientRepository patientRepository;
		private WorkdayRepository workdayRepository;

		public VisitService()
		{
		
		}

		public List<Visit> GetVisitsForPatient(int id)
		{
			List<Visit> visits = visitRepository.GetAll();
			List<Visit> filteredVisits = new List<Visit>();
			if (visits != null)
			{
				foreach (Visit visit in visits)
				{
					if (visit.PatientId == id)
					{
						filteredVisits.Add(visit);
					}
				}
			}
			filteredVisits.Sort((x, y) => y.SerialNumber.CompareTo(x.SerialNumber));
			return filteredVisits;
		}

		public void ScheduleNewVisit(Visit newVisit)
		{
			visitRepository.Save(newVisit);
			workdayRepository.NewVisitTime(newVisit.VisitTime, newVisit.DoctorId);
		}

		public void UpdateVisitInStorage(Visit newVisit)
		{
			visitRepository.Delete(newVisit);
			visitRepository.Save(newVisit);
		}

		public void MarkVisitsIfPatientDidntCome(int id)
		{
			List<Visit> patientsVisits = GetVisitsForPatient(id);
			foreach (Visit visit in patientsVisits)
			{
				if (visit.VisitTime.StartTime.AddHours(2) < DateTime.Now && visit.VisitStatus == VisitStatus.forthcoming)
				{
					visit.VisitStatus = VisitStatus.missed;
					UpdateVisitInStorage(visit);
				}
			}
		}

		public void CancelVisit(Visit visit)
		{
			Visit updatedVisit = visitRepository.Get(visit.Id);

			if (updatedVisit != null)
			{
				updatedVisit.VisitStatus = VisitStatus.canceled;
				UpdateVisitInStorage(updatedVisit);

				Workday workday = workdayRepository.GetWorkday(visit.DoctorId, visit.VisitTime.StartTime);
				workdayRepository.DeleteVisitTime(workday, visit.VisitTime);
				workdayRepository.NewVisitTime(updatedVisit.VisitTime, updatedVisit.DoctorId);
			}
		}

        public void MarkVisitAsRated(Visit visit)
		{
			Visit updatedVisit = visitRepository.Get(visit.Id);
			if (updatedVisit != null)
			{
				updatedVisit.IsReviewed = true;
				UpdateVisitInStorage(updatedVisit);
			}
		}

		public List<int> GetNumberOfVisitsPerMonthForPatient(int id)
		{
			List<Visit> patientsVisits = GetVisitsForPatient(id);
			List<int> monthlyNumberOfVisits = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			foreach (Visit visit in patientsVisits)
			{
				if (visit.VisitStatus == VisitStatus.completed && visit.VisitTime.StartTime.Year == DateTime.Now.Year)
					monthlyNumberOfVisits[visit.VisitTime.StartTime.Month] += 1;
			}
			return monthlyNumberOfVisits;
		}

		public bool IsVisitInNextThreeDays(Visit visit)
		{
			if (DateTime.Now.AddDays(3) <= visit.VisitTime.StartTime)
			{
				return false;
			}
			return true;
		}

		public Visit GetVisitById(int id)
		{
			return visitRepository.Get(id);
		}


		public void DelayVisit(int id, VisitTime delayedVisitTime)
		{
			List<Visit> allVisits = visitRepository.GetAll();
			Visit visit = GetVisitById(id);
			Workday workday = workdayRepository.GetWorkday(visit.DoctorId, visit.VisitTime.StartTime);
			workdayRepository.UpdateVisitTime(workday, visit.VisitTime, delayedVisitTime);
			allVisits.ElementAt(allVisits.IndexOf(visit)).VisitTime = delayedVisitTime;
			visitRepository.SaveAll();
		}


		public List<Visit> GetPatientsVisits(int id)
		{
			List<Visit> patientsVisits = visitRepository.GetPatientsVisits(id);

			return patientsVisits;
		}

		public Visit GetVisit(int doctorId, VisitTime visitTime)
		{
			List<Visit> allVisits = visitRepository.GetAll();
			foreach (Visit visit in allVisits)
			{
				if (visit.DoctorId.Equals(doctorId) && visit.VisitTime.StartTime.Equals(visitTime.StartTime) && visit.VisitTime.EndTime.Equals(visitTime.EndTime))
				{
					return visit;
				}
			}
			return null;
		}

		public List<Visit> GetAllVisits()
		{
			return visitRepository.GetAll();
		}

		public void ScheduleNewExam(Visit visit)
		{
			visitRepository.Save(visit);
		}

		public List<Visit> GetVisitByType(VisitType visitType)
		{
			List<Visit> visits = visitRepository.GetAll();
			List<Visit> Exams = new List<Visit>();
			if (visits != null)
			{
				foreach (Visit visit in visits)
				{
					if (visit.VisitType == visitType)
					{
						Exams.Add(visit);
					}
				}
			}
			return Exams;
		}

		public void CancelOperation(Visit visit)
		{
			Visit updatedVisit = visitRepository.Get(visit.Id);

			if (updatedVisit != null)
			{
				updatedVisit.VisitStatus = VisitStatus.canceled;
				UpdateVisitInStorage(updatedVisit);
			}
		}

		public List<Visit> GetCompletedPatientsVisits(int id)
		{
			List<Visit> allVisits = visitRepository.GetAll();
			List<Visit> patientsVisits = new List<Visit>();
			if (allVisits != null)
			{
				foreach (Visit visit in allVisits)
				{
					if (visit.PatientId == id && visit.VisitStatus == VisitStatus.completed)
					{
						patientsVisits.Add(visit);
					}
				}
			}
			return patientsVisits;
		}

		public Visit GetMostRecentPatientVisitId(int id)
		{
			List<Visit> patientsVisits = GetCompletedPatientsVisits(id);
			Visit mostRecentVisit = patientsVisits.FirstOrDefault();
			foreach (Visit visit in patientsVisits)
			{
				int res = DateTime.Compare(mostRecentVisit.VisitTime.StartTime, visit.VisitTime.StartTime);
				if (res < 0)
				{
					mostRecentVisit = visit;
				}
			}
			return mostRecentVisit;
		}
	}
}
