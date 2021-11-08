using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using HospitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class RoomService: IRoomService
    {
        private IRoomRepository _roomRepository;

        public RoomService() { }
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room GetRoomById(String id)
        {
            return _roomRepository.Get(id);
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAll().ToList();
        }

        public void DeleteRoom(string id)
        {
            Room room = _roomRepository.Get(id);
            if (room != null)
            {
                _roomRepository.Delete(room);
            }
        }
        public List<Room> GetAllNonRenovatedRooms(DateTime now)
        {
            List<Room> nonRenovatedRooms = _roomRepository.GetAll().ToList();
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
            _roomRepository.Save(mergedRooms);

        }
        public void SplitRoom(Room room)
        {
            List<Room> rooms = GetAllRooms();
            DeleteRoom(room.Id);
            Room firstNewRoom = new Room() {Id = room.Id + "R1", Floor=room.Floor, IsRenovated=room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds=room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };
            Room secondNewRoom = new Room() { Id = room.Id + "R2", Floor = room.Floor, IsRenovated = room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds = room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };

            _roomRepository.Save(firstNewRoom);
            _roomRepository.Save(secondNewRoom);
        }

        public void CreateRoom(Room room)
        {
            _roomRepository.Save(room);
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

       
        public Room SetRoom(Room room)
        {
           return _roomRepository.Update(room);
        }

          

            public List<Room> GetRoomsForHospitalization()
            {
                RoomInventoryService roomInventoryService = new RoomInventoryService();
                List<Room> allRooms = _roomRepository.GetAll().ToList();
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

