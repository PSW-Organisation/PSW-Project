using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Utils
{
    public class RoomTermParams
    {
        public List<TimeInterval> TimeIntervalRoomA { get; set; }
        public List<TimeInterval> TimeIntervalRoomB { get; set; }       // if needed
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }

        public RoomTermParams() { }

        public RoomTermParams(List<TimeInterval> timeIntervalRoomA, List<TimeInterval> timeIntervalRoomB, DateTime startTime, DateTime endTime, int durationInMinutes)
        {
            TimeIntervalRoomA = timeIntervalRoomA;
            TimeIntervalRoomB = timeIntervalRoomB;
            StartTime = startTime;
            EndTime = endTime;
            DurationInMinutes = durationInMinutes;
        }
    }
}
