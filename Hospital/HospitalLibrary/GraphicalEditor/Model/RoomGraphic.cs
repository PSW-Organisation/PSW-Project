using System;
using System.ComponentModel;

namespace ehealthcare.Model
{
    public class RoomGraphic : Entity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string DoorPosition { get; set; }

        public string RoomId { get; set; }
        public Room Room { get; set; }


        public RoomGraphic():base("undefinedKey")
        {
        }
    }
}