using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class ParamsOfRenovation
    {
        public ParamsOfRenovation(DateTime startTime, DateTime endTime, int durationInMinutes, int idRoomA, int idRoomB, EquipmentLogic equipmentLogic, string newNameForRoomA, string newSectorForRoomA, RoomType newRoomTypeForRoomA, string newNameForRoomB, string newSectorForRoomB, RoomType newRoomTypeForRoomB)
        {
            StartTime = startTime;
            EndTime = endTime;
            DurationInMinutes = durationInMinutes;
            IdRoomA = idRoomA;
            IdRoomB = idRoomB;
            EquipmentLogic = equipmentLogic;
            NewNameForRoomA = newNameForRoomA;
            NewSectorForRoomA = newSectorForRoomA;
            NewRoomTypeForRoomA = newRoomTypeForRoomA;
            NewNameForRoomB = newNameForRoomB;
            NewSectorForRoomB = newSectorForRoomB;
            NewRoomTypeForRoomB = newRoomTypeForRoomB;
        }

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
        public EquipmentLogic EquipmentLogic { get; set; }
        public string NewNameForRoomA { get; set; }
        public string NewSectorForRoomA { get; set; }
        public RoomType NewRoomTypeForRoomA { get; set; }
        public string NewNameForRoomB { get; set; }         /* if needed */
        public string NewSectorForRoomB { get; set; }       /* if needed */
        public RoomType NewRoomTypeForRoomB { get; set; }   /* if needed */
    }
}
