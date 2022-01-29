using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public class EventMoveEquipmentActions
    {
        public int SourceRoomID { get; set; }

        public int DestinationRoomID { get; set; }

        public string NameOfEquipment { get; set; }

        public int NumberOfEvents { get; set; }
    }
}
