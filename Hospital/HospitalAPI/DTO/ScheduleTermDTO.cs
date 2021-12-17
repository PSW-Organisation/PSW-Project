using HospitalLibrary.RoomsAndEquipment.Terms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class ScheduleTermDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public StateOfTerm TermState { get; set; }
        public string Type { get; set;}
    }
}
