using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Model
{
    public class TermOfRelocationEquipment : EntityDb
    {
        public int IdSourceRoom { get; set; }
        public int IdDestinationRoom { get; set; }
        public string NameOfEquipment { get; set; }
        public int QuantityOfEquipment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationInMinutes { get; set; }
        public bool FinishedRelocation { get; set; }

        public TermOfRelocationEquipment() {}

        public TermOfRelocationEquipment(ParamsOfRelocationEquipment paramsOfRelocationEquipment)
        {
            IdSourceRoom = paramsOfRelocationEquipment.IdSourceRoom;
            IdDestinationRoom = paramsOfRelocationEquipment.IdDestinationRoom;
            NameOfEquipment = paramsOfRelocationEquipment.NameOfEquipment;
            QuantityOfEquipment = paramsOfRelocationEquipment.QuantityOfEquipment;
            StartTime = paramsOfRelocationEquipment.StartTime;
            EndTime = paramsOfRelocationEquipment.EndTime;
            DurationInMinutes = paramsOfRelocationEquipment.DurationInMinutes;
            FinishedRelocation = false;
        }

    }
}
