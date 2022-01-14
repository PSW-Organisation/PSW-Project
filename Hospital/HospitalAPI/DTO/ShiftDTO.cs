    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;

namespace HospitalAPI.DTO
{
    public class ShiftDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ShiftOrder { get; set; }
    }
}
