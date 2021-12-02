using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface ITermOfRelocationEquipmentRepository : IGenericRepository<TermOfRelocationEquipment>
    {
        List<TermOfRelocationEquipment> CheckTermOfRelocationByDate();
        int GetNewID();
        List<TermOfRelocationEquipment> GetTermsOfRelocationByRoomId(int id);
    }
}