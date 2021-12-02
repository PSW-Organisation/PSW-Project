using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public class RoomEquipmentService : IRoomEquipmentService
    {
        private readonly IRoomEquipmentRepository _roomEquipmentRepository;

        public RoomEquipmentService(IRoomEquipmentRepository roomEquipmentRepository)
        {
            _roomEquipmentRepository = roomEquipmentRepository;
        }

        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName)
        {
            return _roomEquipmentRepository.GetEquipmentInRooms(equipmentName);
        }

        public IList<RoomEquipment> GetAllEquipmentInRooms()
        {
            return _roomEquipmentRepository.GetAll();
        }

        public List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity()
        {
            return _roomEquipmentRepository.GetAllRoomEquipmentQuantity();
        }

        public List<RoomEquipment> GetAllEquipmentInRoom(int roomId)
        {
            return _roomEquipmentRepository.GetAllEquipmentInRoom(roomId);
        }
    }
}
