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
        public DateTime endTime { get; set; }
        public int durationInMinutes { get; set; }

        public ParamsOfRelocationEquipmentDTO(){}
        
        public ParamsOfRelocationEquipment GenerateModel()
        {
            ParamsOfRelocationEquipment paramsOfRelocationEquipment = new ParamsOfRelocationEquipment();
            paramsOfRelocationEquipment.IdSourceRoom = IdSourceRoom;
            paramsOfRelocationEquipment.IdDestinationRoom = IdDestinationRoom;
            paramsOfRelocationEquipment.NameOfEquipment = NameOfEquipment;
            paramsOfRelocationEquipment.QuantityOfEquipment = QuantityOfEquipment;
            paramsOfRelocationEquipment.StartTime = StartTime;
            paramsOfRelocationEquipment.endTime = endTime;
            paramsOfRelocationEquipment.durationInMinutes = durationInMinutes;

            return paramsOfRelocationEquipment;
        }
        
    }


}
