using ehealthcare.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomGraphicRepository : GenericDbRepository<RoomGraphic>, IRoomGraphicRepository
    {
        private readonly HospitalDbContext _dbContext;

        public RoomGraphicRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
