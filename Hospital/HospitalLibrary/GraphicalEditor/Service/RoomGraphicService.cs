using ehealthcare.Model;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomGraphicService : IRoomGraphicService
    {
        private IRoomGraphicRepository _roomGraphicRepository;

        public RoomGraphicService(IRoomGraphicRepository roomGraphicRepository)
        {
            _roomGraphicRepository = roomGraphicRepository;
        }

        public Result<IList<RoomGraphic>> GetRoomGraphics()
        {
            return Result.Ok(_roomGraphicRepository.GetAll());
        }

      
    }
}
