using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Utils
{
    public class TimeInterval : BaseValueObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get { return EndTime - StartTime; } }

        public TimeInterval() { }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Validate();
        }

        public bool IsOverlapping(TimeInterval timeInterval)
        {
            if (StartTime >= timeInterval.StartTime &&
                   StartTime <= timeInterval.EndTime ||
                   EndTime >= timeInterval.StartTime &&
                   EndTime <= timeInterval.EndTime ||
                   timeInterval.StartTime >= StartTime &&
                   timeInterval.StartTime <= EndTime ||
                   timeInterval.EndTime >= StartTime &&
                   timeInterval.EndTime <= EndTime)
                return true;

            return false;
        }

        public bool IsOverlapping(DateTime dateTime)
        {
            if (dateTime >= StartTime && dateTime<=EndTime)
                return true;

            return false;
        }

        private bool Validate()
        {
            return StartTime < EndTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}