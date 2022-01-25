using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public class RoomEquipmentRepository : GenericDbRepository<RoomEquipment>, IRoomEquipmentRepository
    {
        private readonly HospitalDbContext _dbContext;

        public RoomEquipmentRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public RoomEquipment GetRoomEquipmentInRoom(int roomId)
        {
            return _dbContext.RoomEquipments.Single(e => e.RoomId == roomId);
        }

        public List<Equipment> GetAllEquipmentInRooms()
        {
            var equipments = new List<Equipment>();
            foreach (var roomEquipment in _dbContext.RoomEquipments)
            {
                equipments.AddRange(roomEquipment.Equipments);
            }

            return equipments;
        }

        public List<RoomEquipmentQuantityDTO> GetAllRoomEquipmentQuantity()
        {
            return GetAllEquipmentInRooms()
                .GroupBy(o => o.Name)
                .Select(g => new RoomEquipmentQuantityDTO
                {
                    Name = g.Key,
                    Quantity = g.Sum(i => i.Quantity)
                }).ToList();
        }

        public List<Equipment> GetEquipmentInRooms(string equipmentName)
        {
            return GetAllEquipmentInRooms().Where(c => c.Name.ToLower().Equals(equipmentName.ToLower()))
                .Select(c => c).ToList();
        }

        public List<Equipment> GetAllEquipmentInRoom(int roomId)
        {
            try
            {
                return _dbContext.RoomEquipments.Single(e => e.RoomId == roomId).Equipments;

            }
            catch (InvalidOperationException exc)
            {
                if (exc.Message == "Sequence contains no elements")
                {
                    return new List<Equipment>();
                }

                throw;
            }
        }

        public Equipment GetEquipmentInRoom(int idRoom, string nameOfEquipment)
        {
            return _dbContext.RoomEquipments.Single(c => c.RoomId == idRoom).Equipments.Single(c => c.Name.Equals(nameOfEquipment));
        }
        
    }
}
