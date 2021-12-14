using System.Collections.Generic;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomEquipmentService
    {
        List<RoomEquipment> GetEquipmentInRooms(string equipmentName);
        IList<RoomEquipment> GetAllEquipmentInRooms();
        List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity();
        List<RoomEquipment> GetAllEquipmentInRoom(int roomId);
        List<RoomEquipment> SplitRoomEquipment(EquipmentLogic equipmentLogic, Room room, List<Room> rooms);
        List<RoomEquipment> MergeRoomEquipment(Room roomA, Room roomB, Room newRoom);
    }
}