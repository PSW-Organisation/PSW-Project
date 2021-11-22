using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository.DbRepository;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomEquipmentRepository : GenericDbRepository<RoomEquipment>, IRoomEquipmentRepository
    {

        HospitalDbContext _dbContext;
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

    }
}
