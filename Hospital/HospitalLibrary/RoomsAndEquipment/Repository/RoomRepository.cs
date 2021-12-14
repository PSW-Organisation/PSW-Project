using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.RoomsAndEquipment.Repository
{
    public class RoomRepository : GenericDbRepository<Room>, IRoomRepository
    {
        private readonly HospitalDbContext _dbContext;

        public RoomRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Room> GetAllByName(string name)
        {
            return _dbContext.Rooms.Where(r => r.Name.ToUpper().Contains(name.ToUpper())).ToList();
        }

        public int GetNewId()
        {
            return _dbContext.Rooms.Max(x => x.Id) + 1;
        }
    }
}
