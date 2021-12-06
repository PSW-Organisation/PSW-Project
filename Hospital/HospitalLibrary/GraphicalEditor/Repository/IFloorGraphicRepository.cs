using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public interface IFloorGraphicRepository : IGenericRepository<FloorGraphic>
    {
        public List<FloorGraphic> GetAllWithRooms();
        public int GetBuildingForRoom(int roomId);
        RoomGraphic GetRoomGraphicByRoomId(int idRoom);
        public List<RoomGraphic> GetAllRoomGraphicOnSameFloor(Room room);
    }
}
