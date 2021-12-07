using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class ParamsOfRenovation
    {
        public ParamsOfRenovation(DateTime startTime, DateTime endTime, int durationInMinutes, int idRoomA, int idRoomB)
        {
            StartTime = startTime;
            EndTime = endTime;
            DurationInMinutes = durationInMinutes;
            IdRoomA = idRoomA;
            IdRoomB = idRoomB;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public int IdRoomA { get; set; }
        public int IdRoomB { get; set; }        /* if needed */
    }
}
