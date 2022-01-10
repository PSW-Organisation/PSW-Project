using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Model
{
    public class VisitTimeInterval : ValueObject
    {
        public int VisitId { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public VisitTimeInterval() { }
        public VisitTimeInterval(int visitId, DateTime startTime, DateTime endTime)
        {
            this.VisitId = visitId;
            this.StartTime = startTime;
            this.EndTime = endTime;
            Validate();
        }

        public VisitTimeInterval(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            Validate();
        }

        private void Validate()
        {
            if (EndTime.Subtract(StartTime) != new TimeSpan(0, 30, 0))
                throw new ArgumentException();
        }

        public VisitTimeInterval Create(int visitId, DateTime startTime, DateTime endTime)
        {
            return new VisitTimeInterval(visitId, startTime, endTime);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}
