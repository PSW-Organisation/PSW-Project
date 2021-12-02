using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomGraphicService : IRoomGraphicService
    {
        private readonly IRoomGraphicRepository _roomGraphicRepository;

        public RoomGraphicService(IRoomGraphicRepository roomGraphicRepository)
        {
            _roomGraphicRepository = roomGraphicRepository;
        }

        public IList<RoomGraphic> GetRoomGraphics()
        {
            return _roomGraphicRepository.GetAll();
        }

    }
}
