using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System.Collections.Generic;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface IRoomEquipmentRepository : IGenericRepository<RoomEquipment>
    {
        public List<RoomEquipmentQuantityDTO> GetAllRoomEquipmentQuantity();
        public RoomEquipment GetEquipmentInRoom(int idRoom, string nameOfEquipment);
        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName);
        public List<RoomEquipment> GetAllEquipmentInRoom(int roomId);
        int GetNewID();
    }
}