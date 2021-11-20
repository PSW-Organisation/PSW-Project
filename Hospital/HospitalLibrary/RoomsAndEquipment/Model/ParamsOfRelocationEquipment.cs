using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class ParamsOfRelocationEquipment
    {
        public int IdSourceRoom { get; set; }
        public int IdDestinationRoom { get; set; }
        public string NameOfEquipment { get; set; }
        public int QuantityOfEquipment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime endTime { get; set; }
        public int durationInMinutes { get; set; }
        public ParamsOfRelocationEquipment() { }
        
    }
}
