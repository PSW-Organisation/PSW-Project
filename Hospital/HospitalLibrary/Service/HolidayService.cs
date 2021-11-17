using System;
using System.Collections.Generic;
using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;

namespace ehealthcare.Service
{
    public class HolidayService
    {
        private HolidayRepository holidayRepository;
        private DoctorRepository doctorRepository;
        private WorkdayRepository workdayRepository;
        private VisitRepository visitRepository;
        private PersonalizedNotificationRepository notificationRepository;
       // private AccountRepository accountRepository;

        public HolidayService()
        {
            holidayRepository = new HolidayXMLRepository();
            doctorRepository = new DoctorXMLRepository();
            workdayRepository = new WorkdayXMLRepository();
            visitRepository = new VisitXMLRepository();
            notificationRepository = new PersonalizedNotificationXMLRepository();
          //  accountRepository = new AccountXMLRepository();
        }

        internal bool CanUseHoliday(Holiday potentialHoliday)
        {
            return potentialHoliday.CanUseHoliday() && !IsOverlapping(potentialHoliday);
        }

        public List<Holiday> GetHolidays(string doctorId)
        {
            return holidayRepository.GetHolidaysForDoctor(doctorId);
        }

        public void NewHoliday(Holiday newHoliday)
        {
            int days = (newHoliday.EndDate - newHoliday.StartDate).Days;

            var cancelledVisits = CancelVisitsInHolidayRange(newHoliday);
            NotifyPatientOfCancellation(cancelledVisits);
            workdayRepository.RemoveWorkdays(newHoliday);

            doctorRepository.UseOffDays(newHoliday.Doctor, days);
            holidayRepository.Save(newHoliday);

        }

        private void NotifyPatientOfCancellation(List<Visit> cancelledVisits)
        {
            foreach (var visit in cancelledVisits)
            {
                List<Account> accounts = new List<Account>();
                //accounts.Add(accountRepository.GetAccountByPatientId(visit.PatientId));
                notificationRepository.NotifyPatientOfCancellation(accounts, visit.VisitTime.StartTime);
            }
        }

        private List<Visit> CancelVisitsInHolidayRange(Holiday newHoliday)
        {
            List<VisitTime> visitForCanceling = workdayRepository.GetVisitTimesInHolidayRange(newHoliday);
            List<Visit> canceledVisits = visitRepository.CancelVisits(visitForCanceling, newHoliday.DoctorId);
            return canceledVisits;
        }

        private bool IsOverlapping(Holiday newHoliday)
        {
            List<Holiday> doctorsHolidays = holidayRepository.GetHolidaysForDoctor(newHoliday.DoctorId);
            foreach (Holiday holiday in doctorsHolidays)
            {
                if (holiday.Overlaps(newHoliday))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
