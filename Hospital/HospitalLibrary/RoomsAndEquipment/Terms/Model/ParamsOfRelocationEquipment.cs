using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class ParamsOfRelocationEquipment
    {
        public int IdSourceRoom { get; set; }
        public int IdDestinationRoom { get; set; }
        public string NameOfEquipment { get; set; }
        public int QuantityOfEquipment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public ParamsOfRelocationEquipment() { }

    }
}
