using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using static ehealthcare.SecretaryApp.Constants;

namespace ehealthcare.Service
{
    public class VisitTimeService
    {

        private WorkdayRepository workdayRepository;
        private VisitRepository visitRepository;
        public VisitTimeService()
        {
            workdayRepository = new WorkdayXMLRepository();
            visitRepository = new VisitXMLRepository();
        }

        public List<DateTime> getFirst21AvailableDates(Doctor doctor)
        {
            List<DateTime> availableDates = new List<DateTime>();

            WorkdayService workdayService = new WorkdayService();
            List<Workday> workdays = workdayService.GetWorkdaysForDoctor(doctor.Id);
            foreach (Workday workday in workdays)
            {

                DateTime startTime = workday.StartTime;
                if (workday.StartTime < DateTime.Now)
                {
                    if (workday.EndTime < DateTime.Now)
                        continue;
                    else
                    {
                        bool shouldStartNextDay = false;
                        int minute = DateTime.Now.Minute;
                        int hour = DateTime.Now.Hour;
                        if (minute < 30)
                        {
                            minute = 30;
                        }
                        else
                        {
                            if (hour + 1 > workday.EndTime.Hour)
                            {
                                shouldStartNextDay = true;
                            }
                            else
                            {
                                hour += 1;
                                minute = 0;
                            }
                        }
                        if (shouldStartNextDay)
                        {
                            continue;
                        }
                        else
                        {
                            startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
                        }
                    }
                }


                int visitTimes = workday.VisitTimes.Count();
                if (visitTimes == 0)
                {
                    availableDates.InsertRange(availableDates.Count(), generateAvailableDateTimesForTimeSpan(startTime, workday.EndTime));
                    if (availableDates.Count() >= 21)
                    {
                        break;
                    }
                }
                else
                {
                    if (workday.VisitTimes[0].StartTime > startTime)
                    {
                        availableDates.InsertRange(availableDates.Count(), generateAvailableDateTimesForTimeSpan(startTime, workday.VisitTimes[0].StartTime));
                        if (availableDates.Count() >= 21)
                        {
                            break;
                        }
                    }
                    if (workday.VisitTimes.Count() > 1)
                    {
                        for (int i = 0; i < visitTimes - 1; i++)
                        {
                            if (workday.VisitTimes[i].EndTime < workday.VisitTimes[i + 1].StartTime)
                            {
                                availableDates.InsertRange(availableDates.Count(), generateAvailableDateTimesForTimeSpan(workday.VisitTimes[i].EndTime, workday.VisitTimes[i + 1].StartTime));
                                if (availableDates.Count() >= 21)
                                {
                                    break;
                                }
                            }
                        }
                        if (availableDates.Count() >= 21)
                        {
                            break;
                        }
                    }
                    if (workday.VisitTimes[visitTimes - 1].EndTime < workday.EndTime)
                    {
                        availableDates.InsertRange(availableDates.Count(), generateAvailableDateTimesForTimeSpan(workday.VisitTimes[visitTimes - 1].EndTime, workday.EndTime));
                        if (availableDates.Count() >= 21)
                        {
                            break;
                        }
                    }
                }

            }
            return availableDates.GetRange(0, 21);
        }

        private List<DateTime> generateAvailableDateTimesForTimeSpan(DateTime start, DateTime end)
        {
            List<DateTime> availableDates = new List<DateTime>();
            int i = 0;
            while (start < end && i < 21)
            {
                availableDates.Add(start);
                start = start.AddMinutes(30);
                i++;
            }
            return availableDates;
        }


        public DateTime GetNearestAvailableTimeSlot(Doctor doctor, DateTime startTime, int duration)
        {
            Workday workday = workdayRepository.GetWorkday(doctor.Id, startTime);
            DateTime nearestTimeSlot = GenerateTimeSlot(workday, startTime, duration);

            return nearestTimeSlot;
        }

        public VisitTime GetNearestAvailableDelay(String doctorId, String patientId, VisitTime takenTimeSlot, List<VisitTime> potentialDelays)
        {
            List<Workday> doctorsWorkdays = workdayRepository.GetWorkdaysAfter(takenTimeSlot.StartTime, doctorId);
            VisitTime availableDelay = new VisitTime();
            foreach (Workday workday in doctorsWorkdays)
            {
                availableDelay = FindAvailableDelay(workday, patientId, takenTimeSlot, potentialDelays);
                if (availableDelay != null)
                {
                    return availableDelay;
                }
            }

            return availableDelay;
        }

        private VisitTime FindAvailableDelay(Workday workday, String patientId, VisitTime takenTimeSlot, List<VisitTime> potentialDelays)
        {
            TimeSpan duration = takenTimeSlot.EndTime - takenTimeSlot.StartTime;
            DateTime start = workday.StartTime;
            DateTime end = workday.StartTime.Add(duration);
            while (end <= workday.EndTime)
            {
                if (start >= takenTimeSlot.EndTime && !workday.IsOverlapping(start, end))
                {
                    VisitTime availableDelay = new VisitTime() { StartTime = start, EndTime = end };
                    if (IsPatientAvailable(patientId, availableDelay) && !IsOverlappingWithPotentialDelays(potentialDelays, availableDelay))
                    {
                        return availableDelay;
                    }
                }
                start = start.AddMinutes(15);
                end = start.Add(duration);
            }
            return null;
        }

        public List<VisitTime> GetDoctorsVisitTimes(Doctor doctor, DateTime startTime, DateTime finishTime)
        {
            List<VisitTime> takenTimeSlots = new List<VisitTime>();
            Workday workday = workdayRepository.GetWorkday(doctor.Id, startTime);

            foreach (VisitTime visitTime in workday.VisitTimes)
            {
                if (IsInDateTimeRange(visitTime, startTime, finishTime))
                {
                    takenTimeSlots.Add(visitTime);
                }
            }

            return takenTimeSlots;
        }

        private bool IsInDateTimeRange(VisitTime visitTime, DateTime startTime, DateTime finishTime)
        {
            return visitTime.StartTime >= startTime && visitTime.StartTime <= finishTime;
        }

        public bool IsPatientAvailable(String patientId, VisitTime visitTime)
        {

            List<Visit> patientsVisits = visitRepository.GetPatientsVisits(patientId);
            foreach (Visit visit in patientsVisits)
            {
                if (visit.VisitTime.StartTime.Date == visitTime.StartTime.Date && visit.VisitStatus == VisitStatus.forthcoming)
                {
                    if (visit.VisitTime.Overlaps(visitTime.StartTime, visitTime.EndTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsOverlappingWithPotentialDelays(List<VisitTime> potentialDelays, VisitTime timeSlot)
        {
            foreach (VisitTime delayedVisitTime in potentialDelays)
            {
                if (delayedVisitTime.Overlaps(timeSlot.StartTime, timeSlot.EndTime))
                {
                    return true;
                }
            }
            return false;
        }

        public List<VisitTime> GetAvailableTimeSlots(string doctorId, DateTime date)
        {
            List<VisitTime> availableTimeSlots = new List<VisitTime>();
            if (workdayRepository.IsWorkday(doctorId, date))
            {
                Workday workday = workdayRepository.GetWorkday(doctorId, date);
                DateTime start = workday.StartTime;
                DateTime end = workday.StartTime.AddMinutes(30);
                availableTimeSlots = GetTimeSlots(workday, start, end);
            }

            return availableTimeSlots;
        }

        public List<VisitTime> GetAvailableTimeSlots(string doctorId)
        {
            List<VisitTime> availableTimeSlots = new List<VisitTime>();
            foreach (Workday workday in workdayRepository.GetWorkdaysAfter(DateTime.Now, doctorId))
            {
                DateTime start = workday.StartTime;
                DateTime end = workday.StartTime.AddMinutes(30);
                availableTimeSlots.AddRange(GetTimeSlots(workday, start, end));
            }

            return availableTimeSlots;
        }

        private List<VisitTime> GetTimeSlots(Workday workday, DateTime start, DateTime end)
        {
            List<VisitTime> availableTimeSlots = new List<VisitTime>();
            while (end <= workday.EndTime)
            {
                if (!workday.IsOverlapping(start, end))
                {
                    VisitTime availableTimeSlot = new VisitTime() { StartTime = start, EndTime = end };
                    availableTimeSlots.Add(availableTimeSlot);
                }
                start = end;
                end = start.AddMinutes(30);
            }

            return availableTimeSlots;
        }

        private DateTime GenerateTimeSlot(Workday workday, DateTime startTime, int duration)
        {
            DateTime timeSlot = new DateTime();
            for (int i = 0; i < FullHour; i++)
            {
                DateTime start = startTime.AddMinutes(i * 5);
                DateTime end = start.AddMinutes(duration);
                if (workday.IsInWorkTime(start, end) && !workday.IsOverlapping(start, end))
                {
                    timeSlot = start;
                    return timeSlot;
                }
            }

            return timeSlot;
        }
    }
}
