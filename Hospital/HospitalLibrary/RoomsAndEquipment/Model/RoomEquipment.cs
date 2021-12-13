using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class RoomEquipment : EntityDb
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int RoomId { get; set; }

        public RoomEquipment()
        {
        }

        public RoomEquipment(RoomEquipment roomEquipment)
        {
            Quantity = roomEquipment.Quantity;
            Name = roomEquipment.Name;
            Type = roomEquipment.Type;
            RoomId = roomEquipment.RoomId;
        }

        public RoomEquipment(int id, int quantity, string name, string type, int roomId)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            Type = type;
            RoomId = roomId;
        }

    }
}
