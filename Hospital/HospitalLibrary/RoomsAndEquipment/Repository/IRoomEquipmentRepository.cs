using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System.Collections.Generic;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public interface IRoomEquipmentRepository : IGenericRepository<RoomEquipment>
    {
        public List<Equipment> GetAllEquipmentInRooms();
        public List<RoomEquipmentQuantityDTO> GetAllRoomEquipmentQuantity();
        public Equipment GetEquipmentInRoom(int idRoom, string nameOfEquipment);
        public List<Equipment> GetEquipmentInRooms(string equipmentName);
        public List<Equipment> GetAllEquipmentInRoom(int roomId);
        public RoomEquipment GetRoomEquipmentInRoom(int roomId);
    }
}