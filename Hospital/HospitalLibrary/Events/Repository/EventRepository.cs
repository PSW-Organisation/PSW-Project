using ehealthcare.Model;
using HospitalLibrary.Events.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.Events.Repository
{
    public class EventRepository : GenericDbRepository<Event>, IEventRepository
    {

        private readonly HospitalDbContext _dbContext;

        public EventRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public object GetAbortStepBreakdown()
        {
            var schedulingAbortions = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Where(q => q.SingleOrDefault(e => e.EventClass.Equals(EventClass.AppointmentSchedulingComplete)) == null)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Step = q.OrderByDescending(e => e.TimeStamp).FirstOrDefault().EventClass
                                            }).ToList();

            return new
            {
                TotalSchedulingAbortions = schedulingAbortions.Count(),
                FirstStepAbortions = schedulingAbortions.Count(a => a.Step.Equals(EventClass.AppointmentSchedulingFirstStep) 
                    || a.Step.Equals(EventClass.AppointmentSchedulingStart)),
                SecondStepAbortions = schedulingAbortions.Count(a => a.Step.Equals(EventClass.AppointmentSchedulingSecondStep)),
                ThirdStepAbortions = schedulingAbortions.Count(a => a.Step.Equals(EventClass.AppointmentSchedulingThirdStep)),
                FourthStepAbortions = schedulingAbortions.Count(a => a.Step.Equals(EventClass.AppointmentSchedulingFourthStep))
            };
        }

        public object GetStepDurationBreakdown()
        {
            return new
            {
                FirstStepDuration = _dbContext.Events.AsEnumerable()
                                        .Where(e => e.EventClass.Equals(EventClass.AppointmentSchedulingFirstStep)
                                        || e.EventClass.Equals(EventClass.AppointmentSchedulingStart))
                                        .Sum(e => e.Duration),
                SecondStepDuration = _dbContext.Events.AsEnumerable()
                                        .Where(e => e.EventClass.Equals(EventClass.AppointmentSchedulingSecondStep))
                                        .Sum(e => e.Duration),
                ThirdStepDuration = _dbContext.Events.AsEnumerable()
                                        .Where(e => e.EventClass.Equals(EventClass.AppointmentSchedulingThirdStep))
                                        .Sum(e => e.Duration),
                FourthStepDuration = _dbContext.Events.AsEnumerable()
                                        .Where(e => e.EventClass.Equals(EventClass.AppointmentSchedulingFourthStep))
                                        .Sum(e => e.Duration)
            };
                                            
        }

        public object GetSuccessfullSchedulingPerMonth()
        {
            var successfullScheduling = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Where(q => q.SingleOrDefault(e => e.EventClass.Equals(EventClass.AppointmentSchedulingComplete)) != null)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Date = q.OrderByDescending(e => e.Id).FirstOrDefault().TimeStamp
                                            }).ToList();

            return new
            {
                Jan = successfullScheduling.Count(a => a.Date.Month == 1),
                Feb = successfullScheduling.Count(a => a.Date.Month == 2),
                Mar = successfullScheduling.Count(a => a.Date.Month == 3),
                Apr = successfullScheduling.Count(a => a.Date.Month == 4),
                May = successfullScheduling.Count(a => a.Date.Month == 5),
                Jun = successfullScheduling.Count(a => a.Date.Month == 6),
                Jul = successfullScheduling.Count(a => a.Date.Month == 7),
                Aug = successfullScheduling.Count(a => a.Date.Month == 8),
                Sep = successfullScheduling.Count(a => a.Date.Month == 9),
                Oct = successfullScheduling.Count(a => a.Date.Month == 10),
                Nov = successfullScheduling.Count(a => a.Date.Month == 11),
                Dec = successfullScheduling.Count(a => a.Date.Month == 12),
            };
        }

        public object GetUnsuccessfullSchedulingPerMonth()
        {
            var unsuccessfullScheduling = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Where(q => q.SingleOrDefault(e => e.EventClass.Equals(EventClass.AppointmentSchedulingComplete)) == null)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Date = q.OrderByDescending(e => e.Id).FirstOrDefault().TimeStamp
                                            }).ToList();
            return new
            {
                Jan = unsuccessfullScheduling.Count(a => a.Date.Month == 1),
                Feb = unsuccessfullScheduling.Count(a => a.Date.Month == 2),
                Mar = unsuccessfullScheduling.Count(a => a.Date.Month == 3),
                Apr = unsuccessfullScheduling.Count(a => a.Date.Month == 4),
                May = unsuccessfullScheduling.Count(a => a.Date.Month == 5),
                Jun = unsuccessfullScheduling.Count(a => a.Date.Month == 6),
                Jul = unsuccessfullScheduling.Count(a => a.Date.Month == 7),
                Aug = unsuccessfullScheduling.Count(a => a.Date.Month == 8),
                Sep = unsuccessfullScheduling.Count(a => a.Date.Month == 9),
                Oct = unsuccessfullScheduling.Count(a => a.Date.Month == 10),
                Nov = unsuccessfullScheduling.Count(a => a.Date.Month == 11),
                Dec = unsuccessfullScheduling.Count(a => a.Date.Month == 12),
            };
        }

        public object GetSchedulingPerTimeOfDay()
        {
            var schedulingPerTimeOfDay = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Date = q.OrderBy(e => e.TimeStamp).FirstOrDefault().TimeStamp
                                            }).ToList();
            return new
            {
                Night = schedulingPerTimeOfDay.Count(s => s.Date.Hour >= 0 && s.Date.Hour < 7),
                Morning = schedulingPerTimeOfDay.Count(s => s.Date.Hour >= 7 && s.Date.Hour < 12),
                Midday = schedulingPerTimeOfDay.Count(s => s.Date.Hour >= 12 && s.Date.Hour < 18),
                Evening = schedulingPerTimeOfDay.Count(s => s.Date.Hour >= 18 && s.Date.Hour < 24)
            };
        }

        public void UpdateEventDuration(string eventGuid, float duration)
        {
            var lastStepEvent = _dbContext.Events.AsEnumerable()
                                    .GroupBy(q => q.EventGuid)
                                    .Where(q => q.Key.ToString() == eventGuid)
                                    .Select(q => q.OrderByDescending(e => e.TimeStamp).FirstOrDefault()).FirstOrDefault();

            lastStepEvent.Duration = duration;
            Update(lastStepEvent);
        }

        public object GetUnsuccessfullSchedulingByAgeGroup()
        {
            var unsuccessfullScheduling = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Where(q => q.SingleOrDefault(e => e.EventClass.Equals(EventClass.AppointmentSchedulingComplete)) == null)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Age = DateTime.Now.Year - _dbContext.Users.FirstOrDefault(u => u.Username == q.FirstOrDefault().IdUser).DateOfBirth.Year
                                            }).ToList();

            return new
            {
                Young = unsuccessfullScheduling.Count(a => a.Age >= 18 && a.Age < 31),
                MiddleAged = unsuccessfullScheduling.Count(a => a.Age >= 31 && a.Age < 46),
                OldAged = unsuccessfullScheduling.Count(a => a.Age >= 46)
            };
        }

        public object GetAverageStats()
        {
            var successfullScheduling = _dbContext.Events.AsEnumerable()
                                            .GroupBy(q => q.EventGuid)
                                            .Where(q => q.SingleOrDefault(e => e.EventClass.Equals(EventClass.AppointmentSchedulingComplete)) != null)
                                            .Select(q => new
                                            {
                                                Guid = q.Key,
                                                Age = DateTime.Now.Year - _dbContext.Users.FirstOrDefault(u => u.Username == q.FirstOrDefault().IdUser).DateOfBirth.Year,
                                                Steps = q.Count() - 1,
                                                Duration = q.Sum(e => e.Duration)
                                            }).ToList();

            return new
            {
                AverageStepsPerScheduling = successfullScheduling.Average(s => s.Steps),
                MaxSteps = successfullScheduling.Max(s => s.Steps),
                AverageDuration = successfullScheduling.Average(s => s.Duration),
                MaxDuration = successfullScheduling.Max(s => s.Duration),
                MinDuration = successfullScheduling.Min(s => s.Duration),
                AverageAge = successfullScheduling.Average(s => s.Age)
            };
        }
    }
}
