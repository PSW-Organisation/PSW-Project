using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository.DbRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class FloorGraphicRepository : GenericSTRINGIDRepository<FloorGraphic>, IFloorGraphicRepository
    {
        HospitalDbContext _dbContext;
        public FloorGraphicRepository(HospitalDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;   
        }

        public IList<FloorGraphic> GetAllWithRooms()
        {
            return _dbContext.FloorGraphics
                .Include(p => p.RoomGraphics)
                .ThenInclude(r => r.Room).ToList();
        }
    }
}