using ehealthcare.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class RoomGraphicRepository : IRoomGraphicRepository
    {
        private HospitalDbContext _dbContext;

        public RoomGraphicRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public string GenerateId()
        {
            throw new NotImplementedException();
        }

        public RoomGraphic Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<RoomGraphic> GetAll()
        {
            return _dbContext.RoomGraphics.ToList();
        }

        public void Save(RoomGraphic entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(RoomGraphic entity)
        {
            throw new NotImplementedException();
        }

        //public Room UpdateRoom(Room room)
        //{
        //    Room foundRoom = _dbContext.Rooms.SingleOrDefault(room => room.Id.Equals(room.Id));
        //    if (foundRoom == null)
        //    {
        //        return null;
        //    }
        //    room.RoomType = roomDTO.RoomType;
        //    _dbContext.Update(room);
        //    _dbContext.SaveChanges();
        //    return room;
        //}
        
    }
}
