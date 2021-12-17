using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class TermOfRenovation : EntityDb
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public StateOfTerm StateOfRenovation { get; set; }
        public TypeOfRenovation TypeOfRenovation { get; set; }
        public int IdRoomA { get; set; }
        public int IdRoomB { get; set; }    /* if needed */
        public EquipmentLogic EquipmentLogic { get; set; }
        public string NewNameForRoomA { get; set; }
        public string NewSectorForRoomA { get; set; }
        public RoomType NewRoomTypeForRoomA { get; set; }
        public string NewNameForRoomB { get; set; }         /* if needed */
        public string NewSectorForRoomB { get; set; }       /* if needed */
        public RoomType NewRoomTypeForRoomB { get; set; }   /* if needed */

        public TermOfRenovation()
        {
        }

    }
}
