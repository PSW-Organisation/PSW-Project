using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System.Collections.Generic;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface IRelocationEquipmentRepository : IGenericRepository<TermOfRelocationEquipment>
    {
        List<TermOfRelocationEquipment> CheckTermOfRelocationByDate();
        int GetNewID();
        List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id);
    }
}