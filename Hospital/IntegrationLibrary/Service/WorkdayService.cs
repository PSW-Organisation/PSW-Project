using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class WorkdayService
	{
		private WorkdayRepository workdayRepository;
        private VisitRepository visitRepository;
        private AccountRepository accountRepository;
        private PersonalizedNotificationRepository notificationRepository;

		public WorkdayService()
		{
			workdayRepository = new WorkdayXMLRepository();
            visitRepository = new VisitXMLRepository();
            accountRepository = new AccountXMLRepository();
            notificationRepository = new PersonalizedNotificationXMLRepository();
        }

        public void NewWorkday(Workday workday)
        {
            workdayRepository.Save(workday);
        }

        public void UpdateWorkHours(Workday workday, DateTime startTime, DateTime endTime)
        {
            Workday updatedWorkday = workdayRepository.UpdateWorkHours(workday, startTime, endTime);
            if (workday.StartTime < startTime || workday.EndTime > endTime)
            {
                List<VisitTime> visitsForCanceling = FindVisitsForCanceling(workday, startTime, endTime);

                workdayRepository.RemoveVisitTimes(updatedWorkday, visitsForCanceling);
                List<Visit> cancelledVisits = visitRepository.CancelVisits(visitsForCanceling, workday.Doctor.Id);
                NotifyPatientOfCancellation(cancelledVisits);
            } 
        }

        private void NotifyPatientOfCancellation(List<Visit> cancelledVisits)
        {
            foreach (var visit in cancelledVisits)
            {
                List<Account> accounts = new List<Account>();
                accounts.Add(accountRepository.GetAccountByPatientId(visit.PatientId));
                notificationRepository.NotifyPatientOfCancellation(accounts, visit.VisitTime.StartTime);
            }
        }

        public List<Workday> GetWorkdaysForDoctor(String doctorId)
        {
            return workdayRepository.GetWorkdaysForDoctor(doctorId);
        }

        public bool IsWorkday(String doctorId, DateTime date)
        {
            return workdayRepository.IsWorkday(doctorId, date);
        }

        public Workday GetWorkday(DateTime date, String doctorId)
        {
            Workday doctorsWorkday = workdayRepository.GetWorkday(doctorId, date);

            return doctorsWorkday;
        }

        public List<Workday> GetWorkdaysAfter(DateTime date, String doctorId)
        {
            List<Workday> workdays = workdayRepository.GetWorkdaysAfter(date, doctorId);

            return workdays;
        }

        public List<Workday> GetWorkdays(int month, String doctorId)
        {
            List<Workday> workdays = workdayRepository.GetWorkdays(month, doctorId);

            return workdays;
        }

        private List<VisitTime> FindVisitsForCanceling(Workday workday, DateTime newWorkdayStart, DateTime newWorkdayEnd)
        {
            List<VisitTime> visitsForCanceling = new List<VisitTime>();
            foreach (VisitTime visitTime in workday.VisitTimes)
            {
                if (visitTime.StartTime < newWorkdayStart || visitTime.EndTime > newWorkdayEnd)
                {
                    visitsForCanceling.Add(visitTime);
                }
            }

            return visitsForCanceling;
        }
    }
}
