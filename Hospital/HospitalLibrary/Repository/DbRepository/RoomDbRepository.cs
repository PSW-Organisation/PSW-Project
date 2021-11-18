using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Repository.DbRepository
{
    public class RoomDbRepository : GenericDbRepository<Room> , IRoomRepository
    {
        public RoomDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }

    }
}
