using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class RoomService
    {
        private RoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomXMLRepository();
        }

        public Room GetRoomById(String id)
        {
            return roomRepository.Get(id);
        }

        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public void DeleteRoom(string id)
        {
            roomRepository.Delete(id);
        }
        public List<Room> GetAllNonRenovatedRooms(DateTime now)
        {
            List<Room> nonRenovatedRooms = roomRepository.GetAll();
            foreach (Room room in nonRenovatedRooms)
            {
                if (room.IsRenovated == false && now <= room.IsRenovatedUntill)
                {
                    room.IsRenovated = false;
                }
            }
            return nonRenovatedRooms;
        }

        public void MergeRooms(Room firstRoom, Room secondRoom)
        {
            List<Room> rooms = GetAllRooms();
            DeleteRoom(firstRoom.Id);
            DeleteRoom(secondRoom.Id);
            Room mergedRooms = new Room() { Id = firstRoom.Id + secondRoom.Id, Floor = firstRoom.Floor, IsRenovated = firstRoom.IsRenovated,
                                            IsRenovatedUntill = firstRoom.IsRenovatedUntill, NumOfTakenBeds = firstRoom.NumOfTakenBeds + secondRoom.NumOfTakenBeds,
                                            Sector = firstRoom.Sector, RoomType = firstRoom.RoomType };
            roomRepository.Save(mergedRooms);

        }
        public void SplitRoom(Room room)
        {
            List<Room> rooms = GetAllRooms();
            DeleteRoom(room.Id);
            Room firstNewRoom = new Room() {Id = room.Id + "R1", Floor=room.Floor, IsRenovated=room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds=room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };
            Room secondNewRoom = new Room() { Id = room.Id + "R2", Floor = room.Floor, IsRenovated = room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds = room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };

            roomRepository.Save(firstNewRoom);
            roomRepository.Save(secondNewRoom);
        }

        public void CreateRoom(Room room)
        {
            roomRepository.Save(room);
        }

        public void CheckIfRoomIsRenovated(ObservableCollection<Room> rooms)
        {
            DateTime now = DateTime.Now;
               foreach(Room room in rooms)
            {
                if(room.IsRenovated ==true && now >= room.IsRenovatedUntill)
                {
                    room.IsRenovated = false;
                }
            }
        }

       
        public void SetRoom(Room room)
        {
            roomRepository.Update(room);
        }

          

            public List<Room> GetRoomsForHospitalization()
            {
                RoomInventoryService roomInventoryService = new RoomInventoryService();
                List<Room> allRooms = roomRepository.GetAll();
                List<Room> freeRooms = new List<Room>();
                if (allRooms != null)
                {
                    foreach (Room room in allRooms)
                    {
                        if (room.RoomType == RoomType.restingRoom && room.NumOfTakenBeds < roomInventoryService.GetNumOfBedsById(room.Id))
                        {
                            freeRooms.Add(room);
                        }
                    }
                }
                return freeRooms;
            }
        }
    
}

