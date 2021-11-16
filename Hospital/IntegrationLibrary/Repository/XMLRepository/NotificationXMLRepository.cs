using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class NotificationXMLRepository : GenericXMLRepository<Notification>, NotificationRepository
	{
		public NotificationXMLRepository() : base("notifications.xml") { }
	}
}
