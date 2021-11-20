using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class TimeInterval
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeInterval() { }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
