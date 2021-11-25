using System.Collections.Generic;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using Microsoft.VisualBasic.CompilerServices;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class FloorGraphicService : IFloorGraphicService
    {
        private IFloorGraphicRepository _floorGraphicRepository;

        public FloorGraphicService(IFloorGraphicRepository floorGraphicRepository)
        {
            _floorGraphicRepository = floorGraphicRepository;
        }

        public Result<IList<FloorGraphic>> GetFloorGraphics()
        {
            return Result.Ok(_floorGraphicRepository.GetAllWithRooms());
        }

        public Result<int> GetBuildingForRoom(int roomId)
        {
            return Result.Ok(_floorGraphicRepository.GetBuildingForRoom(roomId));
        }
    }
}
