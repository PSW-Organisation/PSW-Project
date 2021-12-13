using System.Collections.Generic;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomService
    {
        List<Room> GetAllByName(string name);
        IList<Room> GetAllRooms();
        Room GetRoomById(int id);
        Room SetRoom(Room room);
        Room CreateNewRoom(string name, string sector, int floor, RoomType roomType);
    }
}