using ehealthcare.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.Repository;
using ehealthcare.Repository;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomGraphicRepository : GenericDbRepository<RoomGraphic>, IRoomGraphicRepository
    {
        private HospitalDbContext _dbContext;

        public RoomGraphicRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
