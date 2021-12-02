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

        public List<RoomEquipmentQuantityDTO> GetAllRoomEquipmentQuantity()
        {
            return _dbContext.RoomEquipments
                .GroupBy(o => o.Name)
                .Select(g => new RoomEquipmentQuantityDTO
                {
                    Name = g.Key,
                    Quantity = g.Sum(i => i.Quantity)
                }).ToList();

        }

        public List<RoomEquipment> GetEquipmentInRooms(string equipmentName)
        {
            return _dbContext.RoomEquipments.Where(c => c.Name.ToLower().Equals(equipmentName.ToLower()))
                .Select(c => c).ToList();
        }

        public List<RoomEquipment> GetAllEquipmentInRoom(int roomId)
        {
            return _dbContext.RoomEquipments.Where(e => e.RoomId == roomId).ToList();
        }

        public RoomEquipment GetEquipmentInRoom(int idRoom, string nameOfEquipment)
        {
            return _dbContext.RoomEquipments.SingleOrDefault(c => c.Name.Equals(nameOfEquipment) && c.RoomId == idRoom);
        }

        public int GetNewID()
        {
            return GetAll().Count() + 1;
        }

    }
}
