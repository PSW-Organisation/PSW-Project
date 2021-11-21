using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ehealthcare.Model;

namespace ehealthcare.Service
{
    public interface IRoomService
    {
        void CheckIfRoomIsRenovated(ObservableCollection<Room> rooms);
        void CreateRoom(Room room);
        void DeleteRoom(int id);
        List<Room> GetAllNonRenovatedRooms(DateTime now);
        IList<Room> GetAllRooms();
        Room GetRoomById(int id);
        List<Room> GetRoomsForHospitalization(IRoomInventoryService roomInventoryService);
        void MergeRooms(Room firstRoom, Room secondRoom);
        Room SetRoom(Room room);
        void SplitRoom(Room room);
        IEnumerable<Room> GetAllByName(string name);
    }
}