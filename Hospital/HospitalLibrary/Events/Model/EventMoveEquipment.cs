using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public class EventMoveEquipment: EventBase
    {
        public int SourceRoomID { get; set; }

        public int DestinationRoomID { get; set; }


        public string NameOfEquipment { get; set; }

        public EventMoveEquipment(){}
        public EventMoveEquipment(int sourceRoomId, int destinationRoomId, string nameOfEquipment, int argId,
            String argIdUser) : base(argId, argIdUser)
        {
            SourceRoomID = sourceRoomId;
            DestinationRoomID = destinationRoomId;
            NameOfEquipment = nameOfEquipment;
        }
    }
}
