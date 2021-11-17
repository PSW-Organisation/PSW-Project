using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class RoomService : IRoomService
    {
        private RoomRepository roomRepository;
        private IRoomInventoryService roomInventoryService;

        public RoomService(RoomRepository roomRepository, IRoomInventoryService roomInventoryService)
        {
            this.roomRepository = roomRepository;
            this.roomInventoryService = roomInventoryService;
    }

        public RoomService()
        {
        }

        public Room GetRoomById(int id)
        {
            return roomRepository.Get(id);
        }

        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public void DeleteRoom(Room room)
        {
            roomRepository.Delete(room);
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
            DeleteRoom(firstRoom);
            DeleteRoom(secondRoom);
            Room mergedRooms = new Room() { Id = firstRoom.Id + secondRoom.Id, Floor = firstRoom.Floor, IsRenovated = firstRoom.IsRenovated,
                                            IsRenovatedUntill = firstRoom.IsRenovatedUntill, NumOfTakenBeds = firstRoom.NumOfTakenBeds + secondRoom.NumOfTakenBeds,
                                            Sector = firstRoom.Sector, RoomType = firstRoom.RoomType };
            roomRepository.Save(mergedRooms);

        }
        public void SplitRoom(Room room)
        {
            List<Room> rooms = GetAllRooms();
            DeleteRoom(room);
            Room firstNewRoom = new Room() {Id = roomRepository.GenerateId(), Floor=room.Floor, IsRenovated=room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds=room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };
            Room secondNewRoom = new Room() { Id = roomRepository.GenerateId(), Floor = room.Floor, IsRenovated = room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds = room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };

            roomRepository.Save(firstNewRoom);
            roomRepository.Save(secondNewRoom);
        }

        public void CreateRoom(Room room)
        {
            roomRepository.Save(room);
        }

        public void CheckIfRoomIsRenovated(List<Room> rooms)
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

