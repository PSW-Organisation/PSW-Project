using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Proxies
{
	interface IRoom
	{
		public Room GetRoom(string id);
	}

	public class RoomImpl : IRoom
	{
		RoomRepository roomRepository;
		public Room GetRoom(string id)
		{
			if (roomRepository == null)
				roomRepository = new RoomXMLRepository();
			return roomRepository.Get(id);
		}
	}

	public class RoomProxyImpl : IRoom
	{
		private IRoom room;
		public Room GetRoom(string id)
		{
			if (room == null)
			{
				room = new RoomImpl();
			}
			return room.GetRoom(id);
		}
	}
}
