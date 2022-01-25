using System.Collections.Generic;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomEquipmentService
    {
        List<Equipment> GetEquipmentInRooms(string equipmentName);
        IList<Equipment> GetAllEquipmentInRooms();
        List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity();
        List<Equipment> GetAllEquipmentInRoom(int roomId);
        List<RoomEquipment> SplitRoomEquipment(EquipmentLogic equipmentLogic, Room room, List<Room> rooms);
        RoomEquipment MergeRoomEquipment(Room roomA, Room roomB, Room newRoom);
    }
}