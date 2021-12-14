using ehealthcare.Model;
using ehealthcare.Repository.XMLRepository;
using ehealthcare.Service;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.Get(id);
        }

        public IList<Room> GetAllRooms()
        {
            return _roomRepository.GetAll().ToList();
        }

        public Room SetRoom(Room room)
        {
            return _roomRepository.Update(room);
        }

        public List<Room> GetAllByName(string name)
        {
            return _roomRepository.GetAllByName(name);
        }

        public List<Room> SplitRoom(TermOfRenovation term)
        {
            List<Room> splitRooms = new List<Room>();
            if (term.TypeOfRenovation != TypeOfRenovation.SPLIT) return splitRooms;
            Room room = _roomRepository.Get(term.IdRoomA);
            if (room == null) return splitRooms;
            Room roomA = new Room(term.NewNameForRoomA, term.NewSectorForRoomA, room.Floor, term.NewRoomTypeForRoomA);
            Room roomB = new Room(term.NewNameForRoomB, term.NewSectorForRoomB, room.Floor, term.NewRoomTypeForRoomB);
            var id = GetNewId();
            roomA.Id = id;
            roomB.Id = id + 1;
            splitRooms.Add(roomA);
            splitRooms.Add(roomB);
            return splitRooms;
        }

        private int GetNewId()
        {
            var rooms = _roomRepository.GetAll();
            return rooms.Max(x => x.Id) + 1;
        }

        public Room MergeRoom(TermOfRenovation term)
        {
            Room roomA = _roomRepository.Get(term.IdRoomA);
            Room roomB = _roomRepository.Get(term.IdRoomB);
            if (roomA == null || roomB == null) return null;
            Room newRoom = new Room(term.NewNameForRoomA, term.NewSectorForRoomA, roomA.Floor, term.NewRoomTypeForRoomA);
            newRoom.Id = GetNewId();
            return newRoom;
        }

    }
}

