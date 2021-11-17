using System;
using System.ComponentModel;
using HospitalLibrary.Model;

namespace ehealthcare.Model
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