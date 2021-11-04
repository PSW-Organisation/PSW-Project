using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	class ReminderXMLRepository : GenericXMLRepository<Reminder>, ReminderRepository
	{
		public ReminderXMLRepository() : base("reminders.xml") { }
	}
}
