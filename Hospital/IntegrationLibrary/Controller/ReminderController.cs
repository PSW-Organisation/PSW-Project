using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
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

		public List<Reminder> GetAllRemindersForAccount(int username)
		{
			return reminderService.GetAllRemindersForAccount(username);
		}
	}
}
