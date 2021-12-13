using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalLibrary.RoomsAndEquipment.Terms.Model;

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

        public List<RoomEquipment> SplitRoomEquipment(EquipmentLogic equipmentLogic, Room room, List<Room> rooms)
        {
            List<RoomEquipment> equipments = new List<RoomEquipment>();
            if (room is null || rooms is null) return equipments;
            List<RoomEquipment> roomEquipments = _roomEquipmentRepository.GetAllEquipmentInRoom(room.Id);
            List<RoomEquipment> equipmentA = new List<RoomEquipment>();
            List<RoomEquipment> equipmentB = new List<RoomEquipment>();
            if (equipmentLogic == EquipmentLogic.HALF_IN_A_HALF_IN_B)
            {
                foreach (var equipment in roomEquipments)
                {
                    int quantityA = equipment.Quantity / 2;
                    equipmentA.Add(new RoomEquipment(quantityA, equipment.Name, equipment.Type, rooms[0].Id));
                    int quantityB = equipment.Quantity / 2 + equipment.Quantity % 2;
                    equipmentB.Add(new RoomEquipment(quantityB, equipment.Name, equipment.Type, rooms[1].Id));
                }
            }
            else if (equipmentLogic == EquipmentLogic.ALL_EQUIPMENT_IN_A)
            {
                equipmentA.AddRange(roomEquipments.Select(equipment => new RoomEquipment(equipment.Quantity, equipment.Name, equipment.Type, rooms[0].Id)));
            }
            else if (equipmentLogic == EquipmentLogic.ALL_EQUIPMENT_IN_B)
            {
                equipmentA.AddRange(roomEquipments.Select(equipment => new RoomEquipment(equipment.Quantity, equipment.Name, equipment.Type, rooms[1].Id)));
            }
            equipments.AddRange(equipmentA);
            equipments.AddRange(equipmentB);
            return equipments;
        }

        public List<RoomEquipment> MergeRoomEquipment(Room roomA, Room roomB, Room newRoom)
        {
            List<RoomEquipment> newRoomEquipment = new List<RoomEquipment>();
            if (roomA is null || roomB is null) return newRoomEquipment;
            List<RoomEquipment> roomEquipmentsA = _roomEquipmentRepository.GetAllEquipmentInRoom(roomA.Id);
            List<RoomEquipment> roomEquipmentsB = _roomEquipmentRepository.GetAllEquipmentInRoom(roomB.Id);
            newRoomEquipment.AddRange(roomEquipmentsA.Select(equipment => new RoomEquipment(equipment.Quantity, equipment.Name, equipment.Type, newRoom.Id)));
            
            foreach(RoomEquipment equipment in roomEquipmentsB)
            {
                //if(newRoomEquipment.Find(eq => eq.Name == equipment.Name).Name == equipment.Name) proveriti dal moze ovakav if
                bool added = false;
                foreach(RoomEquipment eq in newRoomEquipment)
                {
                    if(eq.Name == equipment.Name && eq.Type == equipment.Type)
                    {
                        eq.Quantity += equipment.Quantity;
                        added = true;
                        break;
                    }
                }
                if (!added)
                {
                    newRoomEquipment.Add(new RoomEquipment(equipment.Quantity, equipment.Name, equipment.Type, newRoom.Id));
                }
            }

            return newRoomEquipment;
        }
    }
}
