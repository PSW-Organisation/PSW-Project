using System.Collections.Generic;
using HospitalLibrary.Model;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class RoomEquipment : EntityDb
    {
        public int RoomId { get; set; }
        public virtual List<Equipment> Equipments { get; private set; }
        
        public RoomEquipment()
        {
            Equipments = new List<Equipment>();
        }

        public RoomEquipment(int roomId, List<Equipment>  equipments)
        {
            RoomId = roomId;
            Equipments = equipments;
        }
    }
}