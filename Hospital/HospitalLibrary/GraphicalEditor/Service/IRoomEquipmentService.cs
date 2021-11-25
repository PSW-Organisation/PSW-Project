using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IRoomEquipmentService
    {
        public List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity();
        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName);
        public Result<IList<RoomEquipment>> GetAllEquipmentInRooms();
        public List<RoomEquipment> GetAllEquipmentInRoom(int roomId);
    }
}
