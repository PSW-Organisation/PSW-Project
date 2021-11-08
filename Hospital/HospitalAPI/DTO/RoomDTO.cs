using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class RoomDTO
    {
        public string Id { get; set; }
        public String Sector { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsRenovated { get; set; }
        public DateTime IsRenovatedUntil { get; set; }
        public int NumOfTakenBeds { get; set; }
    }
}
