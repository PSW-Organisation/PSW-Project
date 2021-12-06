using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.RoomsAndEquipment.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class FloorGraphicRepository : GenericDbRepository<FloorGraphic>, IFloorGraphicRepository
    {
        private readonly HospitalDbContext _dbContext;

        public FloorGraphicRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FloorGraphic> GetAllWithRooms()
        {
            return _dbContext.FloorGraphics.Include(p => p.RoomGraphics).ThenInclude(r => r.Room).ToList();
        }

        public int GetBuildingForRoom(int roomId)
        {
            FloorGraphic fg = _dbContext.FloorGraphics.First(f => f.RoomGraphics.Any(rg => rg.RoomId == roomId));
            return fg.BuildingId;
        }

        public RoomGraphic GetRoomGraphicByRoomId(int roomId)
        {
            FloorGraphic fg = _dbContext.FloorGraphics.First(f => f.RoomGraphics.Any(rg => rg.RoomId == roomId));
            return fg.RoomGraphics.Single(r => r.Id == roomId);
        }

        public List<RoomGraphic> GetAllRoomGraphicOnSameFloor(Room room)
        {
            FloorGraphic fg = _dbContext.FloorGraphics.First(f => f.RoomGraphics.Any(rg => rg.RoomId == room.Id));
            return fg.RoomGraphics;
        }

    }
}