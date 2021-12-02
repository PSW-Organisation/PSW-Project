using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class ParamsOfRelocationEquipmentDTO
    {
        public int IdSourceRoom{ get; set; }
        public int IdDestinationRoom { get; set; }
        public string NameOfEquipment { get; set; }
        public int QuantityOfEquipment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }

        public ParamsOfRelocationEquipmentDTO()
        {
        }

    }


}
