using Model;
using System;
using System.Collections.Generic;
using vezba.Repository;

namespace Service
{
   public class RoomService
    {
        private IRoomRepository RoomRepository { get; }

        public RoomService()
        {
            RoomRepository = new RoomFileRepository();
        }

        public List<Room> GetAllRooms()
        {
            return RoomRepository.GetAll();
        }

        public Boolean SaveRoom(Room newRoom)
        {
            return RoomRepository.Save(newRoom);
        }

        public Boolean UpdateRoom(Room updatedRoom)
        {
            return RoomRepository.Update(updatedRoom);
        }

        public Boolean DeleteRoom(int roomId)
        {
            return RoomRepository.Delete(roomId);
        }

        public Room GetOneRoom(int roomId)
        {
            return RoomRepository.GetOne(roomId);
        }

        public List<Room> FindAllExistingRooms()
        {
            List<Room> rooms = GetAllRooms();
            List<Room> returnedRooms = new List<Room>();

            foreach (Room room in rooms)
            {
                if (DateTime.Compare(room.StartDateTime, DateTime.Now) <= 0 && DateTime.Compare(room.EndDateTime, DateTime.Now) >= 0)
                {
                    returnedRooms.Add(room);
                }
            }
           
            return returnedRooms;
        }
        
    }
}
