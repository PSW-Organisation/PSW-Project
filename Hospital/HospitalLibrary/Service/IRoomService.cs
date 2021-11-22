using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ehealthcare.Model;

namespace ehealthcare.Service
{
    public interface IRoomService
    {
        public void CheckIfRoomIsRenovated(ObservableCollection<Room> rooms);
        public void CreateRoom(Room room);
        public void DeleteRoom(int id);
        public List<Room> GetAllNonRenovatedRooms(DateTime now);
        public IList<Room> GetAllRooms();
        public Room GetRoomById(int id);
        public List<Room> GetRoomsForHospitalization(IRoomInventoryService roomInventoryService);
        public void MergeRooms(Room firstRoom, Room secondRoom);
        public Room SetRoom(Room room);
        public void SplitRoom(Room room);
        public IEnumerable<Room> GetAllByName(string name);
    }
}