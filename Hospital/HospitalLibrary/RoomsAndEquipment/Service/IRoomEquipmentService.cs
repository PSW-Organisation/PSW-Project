using FluentResults;
using HospitalLibrary.Repository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomEquipmentService
    {
        public List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity();
        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName);
        public IList<RoomEquipment> GetAllEquipmentInRooms();
        public List<RoomEquipment> GetAllEquipmentInRoom(int roomId);
    }
}
