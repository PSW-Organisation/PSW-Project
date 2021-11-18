using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class RoomGraphicDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string DoorPosition { get; set; }
        public RoomType Type { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
