using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentResults;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class RoomEquipmentService : IRoomEquipmentService
    {
        private IRoomEquipmentRepository _roomEquipmentRepository;

        public RoomEquipmentService(IRoomEquipmentRepository roomEquipmentRepository)
        {
            _roomEquipmentRepository = roomEquipmentRepository;
        }

        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName)
        {
            return _roomEquipmentRepository.GetEquipmentInRooms(equipmentName);
        }

        public Result<IList<RoomEquipment>> GetAllEquipmentInRooms()
        {
            return Result.Ok(_roomEquipmentRepository.GetAll());
        }

        public List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity()
        {
            return _roomEquipmentRepository.GetAllRoomEquipmentQuantity();
        }
    }
}
