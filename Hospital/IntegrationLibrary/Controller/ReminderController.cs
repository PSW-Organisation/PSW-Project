using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class ReminderController
	{
		private ReminderService reminderService;

		public ReminderController()
		{
			reminderService = new ReminderService();
		}

		public void CreateNewReminder(Reminder reminder)
		{
			reminderService.CreateNewReminder(reminder);
		}

		public void GenerateNewNoteNotifications()
		{
			reminderService.GenerateNewNoteNotifications();
		}

		public List<Reminder> GetAllRemindersForAccount(string username)
		{
			return reminderService.GetAllRemindersForAccount(username);
		}
	}
}
