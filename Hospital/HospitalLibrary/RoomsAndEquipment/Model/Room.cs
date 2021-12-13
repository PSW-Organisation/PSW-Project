using System;
using System.ComponentModel;
using HospitalLibrary.Model;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class Room : EntityDb
    {
        public string Name { get; set; }
        public string Sector { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsRenovated { get; set; }
        public DateTime IsRenovatedUntill { get; set; }
        public int NumOfTakenBeds { get; set; }

        public Room()
        {
        }
        public Room(string name, string sector, int floor, RoomType roomType)
        {
            Name = name;
            Sector = sector;
            Floor = floor;
            RoomType = roomType;
        }
    }
}