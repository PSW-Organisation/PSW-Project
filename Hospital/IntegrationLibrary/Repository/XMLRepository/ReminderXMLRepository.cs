using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	class ReminderXMLRepository : GenericXMLRepository<Reminder>, ReminderRepository
	{
		public ReminderXMLRepository() : base("reminders.xml") { }
	}
}
