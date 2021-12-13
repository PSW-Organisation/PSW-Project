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

        public List<RoomGraphic> SplitRoomGraphic(Room room, List<Room> rooms)
        {
            List<RoomGraphic> splitRoomGraphics = new List<RoomGraphic>();
            if (room is null || rooms is  null) return splitRoomGraphics;
            RoomGraphic rg = _floorGraphicRepository.GetRoomGraphicByRoomId(room.Id);
            var (doorPosition, xA, yA, widthA, heightA, xB, yB, widthB, heightB) = CalculatePositionAndSize(rg);
            var roomGraphicA = new RoomGraphic(xA, yA, widthA, heightA, doorPosition, rooms[0].Id, rooms[0]);
            var roomGraphicB = new RoomGraphic(xB, yB, widthB, heightB, doorPosition, rooms[1].Id, rooms[1]);
            splitRoomGraphics.Add(roomGraphicA);
            splitRoomGraphics.Add(roomGraphicB);
            return splitRoomGraphics;
        }

        private (string doorPosition, int xA, int yA, int widthA, int heightA, int xB, int yB, int widthB, int heightB)
            CalculatePositionAndSize(RoomGraphic rg)
        {
            string doorPosition = rg.DoorPosition;
            int xA = 0, yA = 0, widthA = 0, heightA = 0, xB = 0, yB = 0, widthB = 0, heightB = 0;
            if (doorPosition == "right" || doorPosition == "left")
            {
                xA = rg.X;
                yA = rg.Y;
                widthA = rg.Width;
                widthB = rg.Width;
                heightA = rg.Height / 2;
                heightB = rg.Height / 2 + rg.Height % 2;
                xB = rg.X;
                yB = yA + heightA;
            }
            else if (doorPosition == "top" || doorPosition == "bottom")
            {
                xA = rg.X;
                yA = rg.Y;
                widthA = rg.Width / 2;
                widthB = rg.Width / 2 + rg.Width % 2;
                heightA = rg.Height;
                heightB = rg.Height;
                xB = xA + widthA;
                yB = rg.Y;
            }
            return (doorPosition, xA, yA, widthA, heightA, xB, yB, widthB, heightB);
        }


        public RoomGraphic MergeRoomGraphic(Room roomA, Room roomB, Room newRoom)
        {
            RoomGraphic roomGraphicA = _floorGraphicRepository.GetRoomGraphicByRoomId(roomA.Id);
            RoomGraphic roomGraphicB = _floorGraphicRepository.GetRoomGraphicByRoomId(roomB.Id);
            RoomGraphic newRoomGraphics = new RoomGraphic(roomGraphicA, roomGraphicB, newRoom);
            return newRoomGraphics;
        }

    }
}
