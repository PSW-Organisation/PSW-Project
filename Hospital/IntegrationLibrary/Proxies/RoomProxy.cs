using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Proxies
{
	interface IRoom
	{
		public Room GetRoom(int id);
	}

	public class RoomImpl : IRoom
	{
		RoomRepository roomRepository;
		public Room GetRoom(int id)
		{
			
			return roomRepository.Get(id);
		}
	}

	public class RoomProxyImpl : IRoom
	{
		private IRoom room;
		public Room GetRoom(int id)
		{
			if (room == null)
			{
				room = new RoomImpl();
			}
			return room.GetRoom(id);
		}
	}
}
