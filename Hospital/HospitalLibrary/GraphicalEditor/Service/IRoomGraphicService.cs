using System.Collections.Generic;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IRoomGraphicService
    {
        IList<RoomGraphic> GetRoomGraphics();
        List<Room> GetAllPossibleRoomsForMergWithRoomById(int idRoom);
        List<RoomGraphic> GetAllPossibleRoomsForMerg(RoomGraphic roomGraphic, Room room);
        List<RoomGraphic> SplitRoomGraphic(Room room, List<Room> rooms);
        RoomGraphic MergeRoomGraphic(Room roomA, Room roomB, Room newRoom);
    }
}