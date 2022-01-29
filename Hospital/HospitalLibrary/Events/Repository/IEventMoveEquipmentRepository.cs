using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using HospitalLibrary.Events.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.Events.Repository
{
    public interface IEventMoveEquipmentRepository: IGenericRepository<EventMoveEquipment>
    {
        public List<EventMoveEquipmentActions> GetActionsForManager(string idUser);
    }
}
