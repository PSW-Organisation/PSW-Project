using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HospitalLibrary.Repository.DbRepository
{
    public class RoomDbRepository : GenericDbRepository<Room> , IRoomRepository
    {
        private readonly HospitalDbContext _dbContext;

        public RoomDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Room> GetAllByName(string name)
        {
            return _dbContext.Rooms.Where(r => r.Name.ToUpper().Contains(name.ToUpper()));
        }
    }
}
