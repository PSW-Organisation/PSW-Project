using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
    public class RoomXMLRepository : GenericXMLRepository<Room>, RoomRepository
    {
        public RoomXMLRepository() : base("rooms.xml") { }
    }
}
