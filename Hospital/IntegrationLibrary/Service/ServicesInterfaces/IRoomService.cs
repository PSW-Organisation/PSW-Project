using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IRoomService
    {
        public Room GetRoomById(int id);
        public List<Room> GetAllRooms();
        public void DeleteRoom(Room room);
        public List<Room> GetAllNonRenovatedRooms(DateTime now);
        public void MergeRooms(Room firstRoom, Room secondRoom);
        public void SplitRoom(Room room);
        public void CreateRoom(Room room);
        public void SetRoom(Room room);
        public List<Room> GetRoomsForHospitalization();
        public void CheckIfRoomIsRenovated(List<Room> rooms);
    }
}
