using ehealthcare.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class RoomXMLRepository : GenericXMLRepository<Room>, IRoomRepository
	{
		public RoomXMLRepository() : base("rooms.xml") { }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Room entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> Search(Expression<Func<Room, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IList<Room> IGenericRepository<Room>.GetAll()
        {
            throw new NotImplementedException();
        }

        Room IGenericRepository<Room>.Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
