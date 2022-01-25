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

        public List<Equipment> GetEquipmentInRooms(string equipmentName)
        {
            return _roomEquipmentRepository.GetEquipmentInRooms(equipmentName);
        }

        public IList<Equipment> GetAllEquipmentInRooms()
        {
            return _roomEquipmentRepository.GetAllEquipmentInRooms();
        }

        public List<RoomEquipmentQuantityDTO> GetRoomEquipmentQuantity()
        {
            return _roomEquipmentRepository.GetAllRoomEquipmentQuantity();
        }

        public List<Equipment> GetAllEquipmentInRoom(int roomId)
        {
            return _roomEquipmentRepository.GetAllEquipmentInRoom(roomId);
        }

        public List<RoomEquipment> SplitRoomEquipment(EquipmentLogic equipmentLogic, Room room, List<Room> rooms)
        {
            List<RoomEquipment> splitRoomEquipment = new List<RoomEquipment>();
            RoomEquipment roomEquipments = _roomEquipmentRepository.GetRoomEquipmentInRoom(room.Id);
            List<Equipment> equipmentA = new List<Equipment>();
            List<Equipment> equipmentB = new List<Equipment>();
            if (equipmentLogic == EquipmentLogic.HALF_IN_A_HALF_IN_B)
            {
                foreach (var equipment in roomEquipments.Equipments)
                {
                    int quantityA = equipment.Quantity / 2;
                    equipmentA.Add(new Equipment(quantityA, equipment.Name, equipment.Type, rooms[0].Id));
                    int quantityB = equipment.Quantity / 2 + equipment.Quantity % 2;
                    equipmentB.Add(new Equipment(quantityB, equipment.Name, equipment.Type, rooms[1].Id));
                }
                splitRoomEquipment.Add(new RoomEquipment(rooms[0].Id, equipmentA));
                splitRoomEquipment.Add(new RoomEquipment(rooms[1].Id, equipmentB));
            }
            else if (equipmentLogic == EquipmentLogic.ALL_EQUIPMENT_IN_A)
            {
                equipmentA.AddRange(roomEquipments.Equipments.Select(equipment =>
                    new Equipment(equipment.Quantity, equipment.Name, equipment.Type, rooms[0].Id)));
                splitRoomEquipment.Add(new RoomEquipment(rooms[0].Id, equipmentA));
            }
            else if (equipmentLogic == EquipmentLogic.ALL_EQUIPMENT_IN_B)
            {
                equipmentB.AddRange(roomEquipments.Equipments.Select(equipment =>
                    new Equipment(equipment.Quantity, equipment.Name, equipment.Type, rooms[1].Id)));
                splitRoomEquipment.Add(new RoomEquipment(rooms[1].Id, equipmentB));
            }

            return splitRoomEquipment;
        }

        public RoomEquipment MergeRoomEquipment(Room roomA, Room roomB, Room newRoom)
        {
            List<Equipment> newRoomEquipment = new List<Equipment>();
            RoomEquipment roomEquipmentsA = _roomEquipmentRepository.GetRoomEquipmentInRoom(roomA.Id);
            RoomEquipment roomEquipmentsB = _roomEquipmentRepository.GetRoomEquipmentInRoom(roomB.Id);
            newRoomEquipment.AddRange(roomEquipmentsA.Equipments.Select(equipment => new Equipment(equipment.Quantity, equipment.Name, equipment.Type, newRoom.Id)));
            
            foreach(Equipment equipment in roomEquipmentsB.Equipments)
            {
                bool added = false;
                foreach(Equipment eq in newRoomEquipment)
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
                    newRoomEquipment.Add(new Equipment(equipment.Quantity, equipment.Name, equipment.Type, newRoom.Id));
                }
            }

            RoomEquipment roomEquipment = new RoomEquipment(newRoom.Id, newRoomEquipment);
            return roomEquipment;
        }
    }
}
