using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository;
using System.Collections.Generic;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IRoomEquipmentRepository : IGenericRepository<RoomEquipment>
    {
        public List<RoomEquipmentQuantityDTO> GetAllRoomEquipmentQuantity();
        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName);
    }
}
