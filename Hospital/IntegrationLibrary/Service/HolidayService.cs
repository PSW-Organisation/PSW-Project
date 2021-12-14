﻿using System;
using System.Collections.Generic;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

namespace IntegrationLibrary.Service
{
    public class HolidayService : IHolidayService
    {
        private HolidayRepository holidayRepository;
        private DoctorRepository doctorRepository;
        private WorkdayRepository workdayRepository;
        private VisitRepository visitRepository;
        private PersonalizedNotificationRepository notificationRepository;
        private AccountRepository accountRepository;

        public HolidayService(HolidayRepository holidayRepository, DoctorRepository doctorRepository, WorkdayRepository workdayRepository, VisitRepository visitRepository, PersonalizedNotificationRepository notificationRepository, AccountRepository accountRepository)
        {
            this.holidayRepository = holidayRepository;
            this.doctorRepository = doctorRepository;
            this.workdayRepository = workdayRepository;
            this.visitRepository = visitRepository;
            this.notificationRepository = notificationRepository;
            this.accountRepository = accountRepository;
        }

        public bool CanUseHoliday(Holiday potentialHoliday)
        {
            return potentialHoliday.CanUseHoliday() && !IsOverlapping(potentialHoliday);
        }

        public List<Holiday> GetHolidays(int doctorId)
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

        public void NotifyPatientOfCancellation(List<Visit> cancelledVisits)
        {
            foreach (var visit in cancelledVisits)
            {
                List<Account> accounts = new List<Account>();
                accounts.Add(accountRepository.GetAccountByPatientId(visit.PatientId));
                notificationRepository.NotifyPatientOfCancellation(accounts, visit.VisitTime.StartTime);
            }
        }

        public List<Visit> CancelVisitsInHolidayRange(Holiday newHoliday)
        {
            List<VisitTime> visitForCanceling = workdayRepository.GetVisitTimesInHolidayRange(newHoliday);
            List<Visit> canceledVisits = visitRepository.CancelVisits(visitForCanceling, newHoliday.DoctorId);
            return canceledVisits;
        }

        public bool IsOverlapping(Holiday newHoliday)
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