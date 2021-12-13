using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomGraphicService : IRoomGraphicService
    {
        private readonly IRoomGraphicRepository _roomGraphicRepository;
        private readonly IFloorGraphicRepository _floorGraphicRepository;
        private readonly IRoomService _roomService;


        public RoomGraphicService(IRoomGraphicRepository roomGraphicRepository, IFloorGraphicRepository floorGraphicRepository, IRoomService roomService)
        {
            _roomGraphicRepository = roomGraphicRepository;
            _roomService = roomService;
            _floorGraphicRepository = floorGraphicRepository;
        }

        public IList<RoomGraphic> GetRoomGraphics()
        {
            return _roomGraphicRepository.GetAll();
        }

        public List<Room> GetAllPossibleRoomsForMergWithRoomById(int idRoom)
        {
            //RoomGraphic roomGraphics = _roomGraphicRepository.GetRoomGraphicByRoomId(idRoom);
            Room room = _roomService.GetRoomById(idRoom);
            if (room == null) return null;

            RoomGraphic roomGraphics = _floorGraphicRepository.GetRoomGraphicByRoomId(idRoom);
            if (roomGraphics == null) return null;

            List<Room> allPossibleRoomsForMerg = new List<Room>();
            foreach(RoomGraphic rg in GetAllPossibleRoomsForMerg(roomGraphics, room))
            {
                allPossibleRoomsForMerg.Add(_roomService.GetRoomById(rg.RoomId));
            }

            return allPossibleRoomsForMerg;
        }

        public List<RoomGraphic> GetAllPossibleRoomsForMerg(RoomGraphic roomGraphic, Room room)
        {
            List<RoomGraphic> allPossibleRoomsForMerg = new List<RoomGraphic>();
            foreach (RoomGraphic rg in _floorGraphicRepository.GetAllRoomGraphicOnSameFloor(room))
            {
                if(roomGraphic.Id != rg.Id)
                {
                    if (roomGraphic.CanBeMerged(rg))
                    {
                        allPossibleRoomsForMerg.Add(rg);
                    }
                }
            }
            return allPossibleRoomsForMerg;
        }

        public RoomGraphic CreateNewRoomGraphic()
        {
            RoomGraphic roomGraphic = new RoomGraphic() {  };



            return roomGraphic;
        }

    }
}
