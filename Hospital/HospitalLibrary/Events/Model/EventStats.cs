using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public class EventStats
    {
        public int SchedulingAbortions { get; set; }

        public EventStats() { }
        public EventStats(int schedulingAbortions)
        {
            SchedulingAbortions = schedulingAbortions;
        }
    }
}
