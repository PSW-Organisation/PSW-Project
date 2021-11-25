using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository.DbRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class FloorGraphicRepository : GenericDbRepository<FloorGraphic>, IFloorGraphicRepository
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

        public int GetBuildingForRoom(int roomId)
        {
            IEnumerable<FloorGraphic> fg = _dbContext.FloorGraphics.ToList().Where(f => f.RoomGraphics.Any(rg=>rg.RoomId.Equals(roomId)));
            return fg.First().BuildingId;
        }
    }
}