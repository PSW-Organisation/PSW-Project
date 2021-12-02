using System;
using System.ComponentModel;
using ehealthcare.Model;
using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class RoomGraphic : EntityDb
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string DoorPosition { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public RoomGraphic()
        {
        }
    }
}