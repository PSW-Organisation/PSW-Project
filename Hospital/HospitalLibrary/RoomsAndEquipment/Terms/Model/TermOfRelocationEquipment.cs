using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class TermOfRelocationEquipment : EntityDb
    {
        public int IdSourceRoom { get; set; }
        public int IdDestinationRoom { get; set; }
        public string NameOfEquipment { get; set; }
        public int QuantityOfEquipment { get; set; }
        
        public TimeInterval Time { get; set; }

        public int DurationInMinutes { get; set; }
        public StateOfTerm RelocationState { get; set; }

        public TermOfRelocationEquipment() { }

        public TermOfRelocationEquipment(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            IdSourceRoom = paramsOfRelocationEquipment.IdSourceRoom;
            IdDestinationRoom = paramsOfRelocationEquipment.IdDestinationRoom;
            NameOfEquipment = paramsOfRelocationEquipment.NameOfEquipment;
            QuantityOfEquipment = paramsOfRelocationEquipment.QuantityOfEquipment;
            Time = new TimeInterval(paramsOfRelocationEquipment.StartTime, paramsOfRelocationEquipment.EndTime);
            DurationInMinutes = paramsOfRelocationEquipment.DurationInMinutes;
            RelocationState = StateOfTerm.PENDING;
        }

    }
}
