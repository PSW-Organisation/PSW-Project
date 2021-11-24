using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface IRelocationEquipmentRepository : IGenericRepository<TermOfRelocationEquipment>
    {
        List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id);

        int GetNewID();
    }
}
