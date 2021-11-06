using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class RoomGraphicDTO
    {
        public string Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string DoorPosition { get; set; }
        public string Type { get; set; }

        public string RoomId { get; set; }

        public Room RoomRef { get; set; }
    }
}
