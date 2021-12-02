using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Proxies
{
	interface IRoom
	{
		public RoomOld GetRoom(string id);
	}

	public class RoomImpl : IRoom
	{
		RoomRepositoryOld roomRepository;
		public RoomOld GetRoom(string id)
		{
			if (roomRepository == null)
				roomRepository = new RoomXMLRepository();
			return roomRepository.Get(id);
		}
	}

	public class RoomProxyImpl : IRoom
	{
		private IRoom room;
		public RoomOld GetRoom(string id)
		{
			if (room == null)
			{
				room = new RoomImpl();
			}
			return room.GetRoom(id);
		}
	}
}
