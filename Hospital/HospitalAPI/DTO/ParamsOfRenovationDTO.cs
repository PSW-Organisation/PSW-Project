using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class ParamsOfRenovationDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public int IdRoomA { get; set; }
        public int IdRoomB { get; set; }        /* if needed */

    }
}
