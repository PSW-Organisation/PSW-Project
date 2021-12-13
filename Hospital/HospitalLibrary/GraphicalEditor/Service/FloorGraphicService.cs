using System.Collections.Generic;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using Microsoft.VisualBasic.CompilerServices;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class FloorGraphicService : IFloorGraphicService
    {
        private readonly IFloorGraphicRepository _floorGraphicRepository;

        public FloorGraphicService(IFloorGraphicRepository floorGraphicRepository)
        {
            _floorGraphicRepository = floorGraphicRepository;
        }

        public List<FloorGraphic> GetFloorGraphics()
        {
            return _floorGraphicRepository.GetAllWithRooms();
        }

        public int GetBuildingForRoom(int roomId)
        {
            return _floorGraphicRepository.GetBuildingForRoom(roomId);
        }

        public RoomGraphic GetRoomGraphicByRoomId(int roomId)
        {
            return _floorGraphicRepository.GetRoomGraphicByRoomId(roomId);
        }
    }
}
