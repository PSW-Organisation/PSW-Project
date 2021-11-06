using System;
using System.ComponentModel;

namespace ehealthcare.Model
{
    public class RoomGraphic : Entity
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int Floor { get; set; }
        public string DoorPosition { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public Room RoomRef { get; set; }


        public RoomGraphic():base("undefinedKey")
        {
        }
    }
}