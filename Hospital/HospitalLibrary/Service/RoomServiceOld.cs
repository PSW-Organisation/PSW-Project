using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class RoomServiceOld
    {
        private RoomRepositoryOld roomRepository;

        public RoomServiceOld()
        {
            roomRepository = new RoomXMLRepository();
        }

        public RoomOld GetRoomById(String id)
        {
            return roomRepository.Get(id);
        }

        public List<RoomOld> GetAllRooms()
        {
            return roomRepository.GetAll();
        }

        public void DeleteRoom(string id)
        {
            roomRepository.Delete(id);
        }
        public List<RoomOld> GetAllNonRenovatedRooms(DateTime now)
        {
            List<RoomOld> nonRenovatedRooms = roomRepository.GetAll();
            foreach (RoomOld room in nonRenovatedRooms)
            {
                if (room.IsRenovated == false && now <= room.IsRenovatedUntill)
                {
                    room.IsRenovated = false;
                }
            }
            return nonRenovatedRooms;
        }

        public void MergeRooms(RoomOld firstRoom, RoomOld secondRoom)
        {
            List<RoomOld> rooms = GetAllRooms();
            DeleteRoom(firstRoom.Id);
            DeleteRoom(secondRoom.Id);
            RoomOld mergedRooms = new RoomOld() { Id = firstRoom.Id + secondRoom.Id, Floor = firstRoom.Floor, IsRenovated = firstRoom.IsRenovated,
                                            IsRenovatedUntill = firstRoom.IsRenovatedUntill, NumOfTakenBeds = firstRoom.NumOfTakenBeds + secondRoom.NumOfTakenBeds,
                                            Sector = firstRoom.Sector, RoomType = firstRoom.RoomType };
            roomRepository.Save(mergedRooms);

        }
        public void SplitRoom(RoomOld room)
        {
            List<RoomOld> rooms = GetAllRooms();
            DeleteRoom(room.Id);
            RoomOld firstNewRoom = new RoomOld() {Id = room.Id + "R1", Floor=room.Floor, IsRenovated=room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds=room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };
            RoomOld secondNewRoom = new RoomOld() { Id = room.Id + "R2", Floor = room.Floor, IsRenovated = room.IsRenovated, IsRenovatedUntill = room.IsRenovatedUntill, NumOfTakenBeds = room.NumOfTakenBeds/2, Sector = room.Sector, RoomType = room.RoomType };

            roomRepository.Save(firstNewRoom);
            roomRepository.Save(secondNewRoom);
        }

        public void CreateRoom(RoomOld room)
        {
            roomRepository.Save(room);
        }

        public void CheckIfRoomIsRenovated(ObservableCollection<RoomOld> rooms)
        {
            DateTime now = DateTime.Now;
               foreach(RoomOld room in rooms)
            {
                if(room.IsRenovated ==true && now >= room.IsRenovatedUntill)
                {
                    room.IsRenovated = false;
                }
            }
        }

       
        public void SetRoom(RoomOld room)
        {
            roomRepository.Update(room);
        }

          

            public List<RoomOld> GetRoomsForHospitalization()
            {
                RoomInventoryService roomInventoryService = new RoomInventoryService();
                List<RoomOld> allRooms = roomRepository.GetAll();
                List<RoomOld> freeRooms = new List<RoomOld>();
                if (allRooms != null)
                {
                    foreach (RoomOld room in allRooms)
                    {
                        if (room.RoomType == RoomTypeOld.restingRoom && room.NumOfTakenBeds < roomInventoryService.GetNumOfBedsById(room.Id))
                        {
                            freeRooms.Add(room);
                        }
                    }
                }
                return freeRooms;
            }
        }
    
}

