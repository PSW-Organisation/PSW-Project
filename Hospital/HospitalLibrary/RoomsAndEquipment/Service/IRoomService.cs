using System.Collections.Generic;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomService
    {
        Room GetRoomById(int id);
        IList<Room> GetAllRooms();
        Room SetRoom(Room room);
        List<Room> GetAllByName(string name);
        List<Room> SplitRoom(TermOfRenovation term);
        Room MergeRoom(TermOfRenovation term);
    }
}