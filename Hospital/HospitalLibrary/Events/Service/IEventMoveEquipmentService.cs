using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.Events.Model;

namespace HospitalLibrary.Events.Service
{
    public interface IEventMoveEquipmentService
    { 
        public EventMoveEquipment GetMoveEquipmentEvent(int id);

        public IList<EventMoveEquipment> GetAllMoveEquipmentEvents();

        public void SaveMoveEquipmentEvent(EventMoveEquipment e);

        public List<EventMoveEquipmentActions> GetMoveEquipmentEventActions(string idUser);
    }
}
