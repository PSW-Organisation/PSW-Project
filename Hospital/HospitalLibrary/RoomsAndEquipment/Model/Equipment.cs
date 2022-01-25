using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class Equipment : EntityDb
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int RoomEquipmentId { get; set; }

        public Equipment()
        {
        }

        public Equipment(Equipment equipment)
        {
            Quantity = equipment.Quantity;
            Name = equipment.Name;
            Type = equipment.Type;
            RoomEquipmentId = equipment.RoomEquipmentId;
        }

        public Equipment(int quantity, string name, string type, int roomId)
        {
            Quantity = quantity;
            Name = name;
            Type = type;
            RoomEquipmentId = RoomEquipmentId;
        }

        public Equipment(int id, int quantity, string name, string type, int roomId)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            Type = type;
            RoomEquipmentId = RoomEquipmentId;
        }

    }
}
